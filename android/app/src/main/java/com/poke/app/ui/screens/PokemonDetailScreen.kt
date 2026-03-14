package com.poke.app.ui.screens

import androidx.compose.foundation.layout.*
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.automirrored.filled.ArrowBack
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import coil.compose.AsyncImage
import com.poke.app.data.GameData
import com.poke.app.data.PokemonType
import com.poke.app.data.TypeEffectiveness
import com.poke.app.ui.components.StatBar
import com.poke.app.ui.components.TypeBadge

@OptIn(ExperimentalMaterial3Api::class, ExperimentalLayoutApi::class)
@Composable
fun PokemonDetailScreen(pokemonName: String, onBack: () -> Unit) {
    val pokemon = remember(pokemonName) { GameData.pokemon.find { it.name == pokemonName } }

    Scaffold(
        topBar = {
            TopAppBar(
                title = { Text(pokemon?.name ?: "Unknown") },
                navigationIcon = {
                    IconButton(onClick = onBack) {
                        Icon(Icons.AutoMirrored.Filled.ArrowBack, contentDescription = "Back")
                    }
                }
            )
        }
    ) { padding ->
        if (pokemon == null) {
            Box(Modifier.fillMaxSize().padding(padding), contentAlignment = Alignment.Center) {
                Text("Pokémon not found")
            }
            return@Scaffold
        }
        Column(
            modifier = Modifier
                .fillMaxSize()
                .padding(padding)
                .verticalScroll(rememberScrollState())
                .padding(16.dp),
            horizontalAlignment = Alignment.CenterHorizontally
        ) {
            AsyncImage(
                model = pokemon.spriteUrl,
                contentDescription = pokemon.name,
                modifier = Modifier
                    .size(128.dp)
                    .clip(RoundedCornerShape(12.dp))
            )
            Spacer(Modifier.height(8.dp))
            Text(
                text = "#${String.format("%03d", pokemon.number)} ${pokemon.name}",
                fontSize = 22.sp,
                fontWeight = FontWeight.Bold
            )
            Spacer(Modifier.height(6.dp))
            Row(horizontalArrangement = Arrangement.spacedBy(6.dp)) {
                TypeBadge(pokemon.primaryType)
                pokemon.secondaryType?.let { TypeBadge(it) }
            }

            Spacer(Modifier.height(16.dp))
            SectionTitle("Base Stats")
            StatBar("HP", pokemon.hp)
            StatBar("Attack", pokemon.attack)
            StatBar("Defense", pokemon.defense)
            StatBar("Sp. Atk", pokemon.spAttack)
            StatBar("Sp. Def", pokemon.spDefense)
            StatBar("Speed", pokemon.speed)
            HorizontalDivider(modifier = Modifier.padding(vertical = 4.dp))
            StatBar("Total", pokemon.baseStatTotal, 600)

            Spacer(Modifier.height(16.dp))
            SectionTitle("Abilities")
            AbilityRow(pokemon.ability1, false)
            pokemon.ability2?.let { AbilityRow(it, false) }
            pokemon.hiddenAbility?.let { AbilityRow(it, true) }

            Spacer(Modifier.height(16.dp))
            SectionTitle("Type Effectiveness (defending)")
            TypeDefenseSection(pokemon.primaryType, pokemon.secondaryType)

            if (pokemon.learnset.isNotEmpty()) {
                Spacer(Modifier.height(16.dp))
                SectionTitle("Learnset")
                pokemon.learnset.forEach { move ->
                    Text("• $move", modifier = Modifier.fillMaxWidth().padding(vertical = 2.dp))
                }
            }
        }
    }
}

@Composable
private fun SectionTitle(text: String) {
    Text(
        text = text,
        fontWeight = FontWeight.Bold,
        fontSize = 16.sp,
        modifier = Modifier
            .fillMaxWidth()
            .padding(bottom = 6.dp)
    )
}

@Composable
private fun AbilityRow(name: String, isHidden: Boolean) {
    val ability = remember(name) { GameData.abilities.find { it.name.equals(name, ignoreCase = true) } }
    Card(
        modifier = Modifier
            .fillMaxWidth()
            .padding(vertical = 3.dp),
        colors = CardDefaults.cardColors(
            containerColor = if (isHidden)
                MaterialTheme.colorScheme.surfaceVariant
            else MaterialTheme.colorScheme.surface
        )
    ) {
        Column(Modifier.padding(10.dp)) {
            Row(verticalAlignment = Alignment.CenterVertically) {
                Text(name, fontWeight = FontWeight.SemiBold)
                if (isHidden) {
                    Spacer(Modifier.width(6.dp))
                    Text("(Hidden)", fontSize = 11.sp, color = MaterialTheme.colorScheme.onSurface.copy(alpha = 0.5f))
                }
            }
            if (ability != null && ability.description.isNotEmpty()) {
                Text(ability.description, fontSize = 12.sp, color = MaterialTheme.colorScheme.onSurface.copy(alpha = 0.7f))
            }
        }
    }
}

@OptIn(ExperimentalLayoutApi::class)
@Composable
private fun TypeDefenseSection(type1: PokemonType, type2: PokemonType?) {
    val grouped = PokemonType.values()
        .groupBy { atk -> TypeEffectiveness.getCombinedEffectiveness(atk, type1, type2) }
        .toSortedMap()

    grouped.forEach { (multiplier, types) ->
        val label = when (multiplier) {
            0f -> "Immune (0×)"
            0.25f -> "¼×"
            0.5f -> "½×"
            1f -> return@forEach
            2f -> "2×"
            4f -> "4×"
            else -> "${multiplier}×"
        }
        val bgColor = when (multiplier) {
            0f -> MaterialTheme.colorScheme.surfaceVariant
            0.25f, 0.5f -> androidx.compose.ui.graphics.Color(0xFFBBDEFB)
            2f -> androidx.compose.ui.graphics.Color(0xFFFFCDD2)
            4f -> androidx.compose.ui.graphics.Color(0xFFE53935).copy(alpha = 0.3f)
            else -> MaterialTheme.colorScheme.surface
        }
        Text(label, fontWeight = FontWeight.SemiBold, fontSize = 13.sp, modifier = Modifier.padding(top = 4.dp))
        androidx.compose.foundation.layout.FlowRow(
            horizontalArrangement = Arrangement.spacedBy(4.dp),
            modifier = Modifier.padding(bottom = 4.dp)
        ) {
            types.forEach { t -> TypeBadge(t) }
        }
    }
}
