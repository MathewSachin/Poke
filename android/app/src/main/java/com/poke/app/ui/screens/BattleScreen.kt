package com.poke.app.ui.screens

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.verticalScroll
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.automirrored.filled.ArrowBack
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import coil.compose.AsyncImage
import com.poke.app.data.GameData
import com.poke.app.data.PokemonSpecies
import com.poke.app.data.PokemonType
import com.poke.app.data.TypeEffectiveness
import com.poke.app.ui.components.TypeBadge
import kotlin.random.Random

data class BattleState(
    val playerPokemon: PokemonSpecies,
    val opponentPokemon: PokemonSpecies,
    val playerHp: Int,
    val opponentHp: Int,
    val playerMaxHp: Int,
    val opponentMaxHp: Int,
    val log: List<String>,
    val battleOver: Boolean,
    val winner: String?
)

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun BattleScreen(onBack: () -> Unit) {
    // Pick random Pokémon for each side
    val playerPoke = remember { GameData.pokemon.random() }
    val opponentPoke = remember {
        val p = GameData.pokemon.filter { it.name != playerPoke.name }.random()
        p
    }

    var state by remember {
        mutableStateOf(
            BattleState(
                playerPokemon = playerPoke,
                opponentPokemon = opponentPoke,
                playerHp = playerPoke.hp,
                opponentHp = opponentPoke.hp,
                playerMaxHp = playerPoke.hp,
                opponentMaxHp = opponentPoke.hp,
                log = listOf("A wild ${opponentPoke.name} appeared!"),
                battleOver = false,
                winner = null
            )
        )
    }

    val playerMoves = remember(playerPoke) {
        if (playerPoke.learnset.isNotEmpty())
            playerPoke.learnset.take(4).mapNotNull { moveName -> GameData.moves.find { it.name == moveName } }
        else GameData.moves.filter { it.kind != com.poke.app.data.MoveKind.Status }.shuffled().take(4)
    }

    Scaffold(
        topBar = {
            TopAppBar(
                title = { Text("Battle Simulator") },
                navigationIcon = {
                    IconButton(onClick = onBack) {
                        Icon(Icons.AutoMirrored.Filled.ArrowBack, contentDescription = "Back")
                    }
                }
            )
        }
    ) { padding ->
        Column(
            modifier = Modifier
                .fillMaxSize()
                .padding(padding)
                .verticalScroll(rememberScrollState())
        ) {
            // Battle arena
            Row(
                modifier = Modifier
                    .fillMaxWidth()
                    .background(Color(0xFFE8F5E9))
                    .padding(16.dp),
                horizontalArrangement = Arrangement.SpaceBetween
            ) {
                // Player
                BattlerCard(
                    pokemon = state.playerPokemon,
                    hp = state.playerHp,
                    maxHp = state.playerMaxHp,
                    label = "You",
                    modifier = Modifier.weight(1f)
                )
                Text("VS", modifier = Modifier.align(Alignment.CenterVertically).padding(8.dp),
                    fontWeight = FontWeight.Bold, fontSize = 20.sp, color = Color.Gray)
                // Opponent
                BattlerCard(
                    pokemon = state.opponentPokemon,
                    hp = state.opponentHp,
                    maxHp = state.opponentMaxHp,
                    label = "Foe",
                    modifier = Modifier.weight(1f)
                )
            }

            // Battle log
            Card(
                modifier = Modifier
                    .fillMaxWidth()
                    .padding(horizontal = 16.dp, vertical = 8.dp)
                    .height(140.dp),
                colors = CardDefaults.cardColors(containerColor = Color(0xFF1A1A2E))
            ) {
                Column(
                    modifier = Modifier
                        .fillMaxSize()
                        .padding(12.dp)
                        .verticalScroll(rememberScrollState())
                ) {
                    state.log.takeLast(10).forEach { line ->
                        Text(line, color = Color.White, fontSize = 13.sp, modifier = Modifier.padding(vertical = 1.dp))
                    }
                }
            }

            if (!state.battleOver) {
                Text(
                    "Choose a move:",
                    modifier = Modifier.padding(horizontal = 16.dp, vertical = 4.dp),
                    fontWeight = FontWeight.SemiBold
                )
                // Move buttons
                Column(modifier = Modifier.padding(horizontal = 16.dp)) {
                    playerMoves.chunked(2).forEach { pair ->
                        Row(horizontalArrangement = Arrangement.spacedBy(8.dp), modifier = Modifier.fillMaxWidth()) {
                            pair.forEach { move ->
                                OutlinedButton(
                                    onClick = {
                                        state = simulateTurn(state, move, GameData.moves.filter { it.kind != com.poke.app.data.MoveKind.Status }.random())
                                    },
                                    modifier = Modifier.weight(1f)
                                ) {
                                    Column(horizontalAlignment = Alignment.CenterHorizontally) {
                                        Text(move.name, fontSize = 12.sp, fontWeight = FontWeight.Bold)
                                        TypeBadge(move.type)
                                    }
                                }
                            }
                        }
                        Spacer(Modifier.height(6.dp))
                    }
                }
            } else {
                Card(
                    modifier = Modifier.fillMaxWidth().padding(16.dp),
                    colors = CardDefaults.cardColors(
                        containerColor = when (state.winner) {
                            "player" -> Color(0xFF2E7D32)
                            "draw" -> Color(0xFF6D4C41)
                            else -> Color(0xFFC62828)
                        }
                    )
                ) {
                    Text(
                        when (state.winner) {
                            "player" -> "🏆 You won!"
                            "draw" -> "🤝 It's a draw!"
                            else -> "💀 You lost..."
                        },
                        modifier = Modifier.padding(24.dp).fillMaxWidth(),
                        color = Color.White,
                        fontWeight = FontWeight.Bold,
                        fontSize = 22.sp,
                        textAlign = TextAlign.Center
                    )
                }
                Button(
                    onClick = {
                        val newPlayer = GameData.pokemon.random()
                        val newOpp = GameData.pokemon.filter { it.name != newPlayer.name }.random()
                        state = BattleState(
                            playerPokemon = newPlayer, opponentPokemon = newOpp,
                            playerHp = newPlayer.hp, opponentHp = newOpp.hp,
                            playerMaxHp = newPlayer.hp, opponentMaxHp = newOpp.hp,
                            log = listOf("A wild ${newOpp.name} appeared!"), battleOver = false, winner = null
                        )
                    },
                    modifier = Modifier.fillMaxWidth().padding(horizontal = 16.dp)
                ) { Text("New Battle") }
            }
            Spacer(Modifier.height(16.dp))
        }
    }
}

@Composable
private fun BattlerCard(
    pokemon: PokemonSpecies,
    hp: Int,
    maxHp: Int,
    label: String,
    modifier: Modifier = Modifier
) {
    Column(modifier = modifier, horizontalAlignment = Alignment.CenterHorizontally) {
        Text(label, fontSize = 11.sp, color = Color.Gray)
        AsyncImage(
            model = pokemon.spriteUrl,
            contentDescription = pokemon.name,
            modifier = Modifier.size(80.dp)
        )
        Text(pokemon.name, fontWeight = FontWeight.Bold, fontSize = 13.sp)
        Row(horizontalArrangement = Arrangement.spacedBy(4.dp)) {
            TypeBadge(pokemon.primaryType)
        }
        Spacer(Modifier.height(4.dp))
        val hpRatio = hp.toFloat() / maxHp
        val barColor = when {
            hpRatio > 0.5f -> Color(0xFF43A047)
            hpRatio > 0.2f -> Color(0xFFFFA726)
            else -> Color(0xFFE53935)
        }
        LinearProgressIndicator(
            progress = { hpRatio.coerceIn(0f, 1f) },
            modifier = Modifier.fillMaxWidth().height(8.dp),
            color = barColor,
            trackColor = barColor.copy(alpha = 0.2f)
        )
        Text("$hp / $maxHp HP", fontSize = 10.sp, color = Color.Gray)
    }
}

private fun simulateTurn(
    state: BattleState,
    playerMove: com.poke.app.data.MoveInfo,
    opponentMove: com.poke.app.data.MoveInfo
): BattleState {
    val newLog = state.log.toMutableList()
    var pHp = state.playerHp
    var oHp = state.opponentHp

    // Determine who goes first based on speed
    val playerFirst = state.playerPokemon.speed >= state.opponentPokemon.speed

    fun calcDamage(attacker: PokemonSpecies, move: com.poke.app.data.MoveInfo, defender: PokemonSpecies): Int {
        if (move.power == null || move.kind == com.poke.app.data.MoveKind.Status) return 0
        val atk = if (move.kind == com.poke.app.data.MoveKind.Physical) attacker.attack else attacker.spAttack
        val def = if (move.kind == com.poke.app.data.MoveKind.Physical) defender.defense else defender.spDefense
        val typeEff = TypeEffectiveness.getCombinedEffectiveness(move.type, defender.primaryType, defender.secondaryType)
        val stab = if (move.type == attacker.primaryType || move.type == attacker.secondaryType) 1.5f else 1f
        val randomFactor = Random.nextFloat() * 0.15f + 0.85f
        val damage = ((((2 * 50 / 5 + 2) * move.power * atk / def) / 50 + 2) * stab * typeEff * randomFactor).toInt()
        return damage.coerceAtLeast(1)
    }

    fun attackOpp() {
        val dmg = calcDamage(state.playerPokemon, playerMove, state.opponentPokemon)
        oHp = (oHp - dmg).coerceAtLeast(0)
        val eff = TypeEffectiveness.getCombinedEffectiveness(playerMove.type, state.opponentPokemon.primaryType, state.opponentPokemon.secondaryType)
        val effStr = when { eff == 0f -> " It had no effect!"; eff < 1f -> " It's not very effective..."; eff > 1f -> " It's super effective!" else -> "" }
        newLog += "${state.playerPokemon.name} used ${playerMove.name}! Dealt $dmg dmg.$effStr"
    }

    fun attackPlayer() {
        val dmg = calcDamage(state.opponentPokemon, opponentMove, state.playerPokemon)
        pHp = (pHp - dmg).coerceAtLeast(0)
        val eff = TypeEffectiveness.getCombinedEffectiveness(opponentMove.type, state.playerPokemon.primaryType, state.playerPokemon.secondaryType)
        val effStr = when { eff == 0f -> " No effect!"; eff < 1f -> " Not very effective..."; eff > 1f -> " Super effective!" else -> "" }
        newLog += "${state.opponentPokemon.name} used ${opponentMove.name}! Dealt $dmg dmg.$effStr"
    }

    if (playerFirst) {
        attackOpp()
        if (oHp > 0) attackPlayer()
    } else {
        attackPlayer()
        if (pHp > 0) attackOpp()
    }

    val over = pHp <= 0 || oHp <= 0
    val winner = when {
        pHp <= 0 && oHp <= 0 -> "draw"
        oHp <= 0 -> { newLog += "${state.opponentPokemon.name} fainted!"; "player" }
        pHp <= 0 -> { newLog += "${state.playerPokemon.name} fainted!"; "opponent" }
        else -> null
    }

    return state.copy(
        playerHp = pHp,
        opponentHp = oHp,
        log = newLog,
        battleOver = over,
        winner = winner
    )
}
