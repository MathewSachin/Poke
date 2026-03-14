package com.poke.app.ui.screens

import androidx.compose.foundation.background
import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.foundation.verticalScroll
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Add
import androidx.compose.material.icons.filled.Clear
import androidx.compose.material.icons.filled.PlayArrow
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import androidx.compose.ui.window.Dialog
import coil.compose.AsyncImage
import com.poke.app.data.GameData
import com.poke.app.data.PokemonSpecies
import com.poke.app.ui.components.TypeBadge

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun TeamBuilderScreen(onBattleClick: () -> Unit) {
    val team = remember { mutableStateListOf<PokemonSpecies?>(*arrayOfNulls(6)) }
    var showPickerForSlot by remember { mutableStateOf<Int?>(null) }

    Column(modifier = Modifier.fillMaxSize().padding(16.dp)) {
        Text("Team Builder", style = MaterialTheme.typography.headlineSmall, fontWeight = FontWeight.Bold)
        Spacer(Modifier.height(12.dp))

        for (i in 0..5) {
            TeamSlot(
                index = i,
                pokemon = team[i],
                onAdd = { showPickerForSlot = i },
                onRemove = { team[i] = null }
            )
            Spacer(Modifier.height(8.dp))
        }

        Spacer(Modifier.height(12.dp))
        Button(
            onClick = onBattleClick,
            modifier = Modifier.fillMaxWidth(),
            enabled = team.any { it != null }
        ) {
            Icon(Icons.Filled.PlayArrow, contentDescription = null)
            Spacer(Modifier.width(8.dp))
            Text("Battle Simulator")
        }
    }

    showPickerForSlot?.let { slot ->
        PokemonPickerDialog(
            onDismiss = { showPickerForSlot = null },
            onPick = { pokemon ->
                team[slot] = pokemon
                showPickerForSlot = null
            }
        )
    }
}

@Composable
private fun TeamSlot(
    index: Int,
    pokemon: PokemonSpecies?,
    onAdd: () -> Unit,
    onRemove: () -> Unit
) {
    Card(
        modifier = Modifier.fillMaxWidth(),
        elevation = CardDefaults.cardElevation(defaultElevation = 2.dp)
    ) {
        Row(
            modifier = Modifier.padding(10.dp),
            verticalAlignment = Alignment.CenterVertically
        ) {
            Text(
                "${index + 1}.",
                modifier = Modifier.width(24.dp),
                fontWeight = FontWeight.Bold,
                color = MaterialTheme.colorScheme.onSurface.copy(alpha = 0.5f)
            )
            if (pokemon != null) {
                AsyncImage(
                    model = pokemon.spriteUrl,
                    contentDescription = pokemon.name,
                    modifier = Modifier.size(52.dp).clip(RoundedCornerShape(8.dp))
                )
                Spacer(Modifier.width(10.dp))
                Column(modifier = Modifier.weight(1f)) {
                    Text(pokemon.name, fontWeight = FontWeight.Bold)
                    Row(horizontalArrangement = Arrangement.spacedBy(4.dp)) {
                        TypeBadge(pokemon.primaryType)
                        pokemon.secondaryType?.let { TypeBadge(it) }
                    }
                }
                IconButton(onClick = onRemove) {
                    Icon(Icons.Filled.Clear, contentDescription = "Remove", tint = MaterialTheme.colorScheme.error)
                }
            } else {
                Box(
                    modifier = Modifier
                        .size(52.dp)
                        .clip(RoundedCornerShape(8.dp))
                        .background(MaterialTheme.colorScheme.surfaceVariant),
                    contentAlignment = Alignment.Center
                ) {
                    Text("?", fontSize = 22.sp, color = MaterialTheme.colorScheme.onSurfaceVariant)
                }
                Spacer(Modifier.width(10.dp))
                Text(
                    "Empty slot",
                    modifier = Modifier.weight(1f),
                    color = MaterialTheme.colorScheme.onSurface.copy(alpha = 0.4f)
                )
                IconButton(onClick = onAdd) {
                    Icon(Icons.Filled.Add, contentDescription = "Add Pokémon")
                }
            }
        }
    }
}

@OptIn(ExperimentalMaterial3Api::class)
@Composable
private fun PokemonPickerDialog(
    onDismiss: () -> Unit,
    onPick: (PokemonSpecies) -> Unit
) {
    var query by remember { mutableStateOf("") }
    val filtered = remember(query) {
        GameData.pokemon.filter { p ->
            query.isBlank() || p.name.contains(query, ignoreCase = true)
        }
    }

    Dialog(onDismissRequest = onDismiss) {
        Surface(shape = RoundedCornerShape(16.dp), modifier = Modifier.fillMaxHeight(0.85f)) {
            Column(modifier = Modifier.padding(16.dp)) {
                Text("Choose a Pokémon", fontWeight = FontWeight.Bold, fontSize = 18.sp)
                Spacer(Modifier.height(8.dp))
                OutlinedTextField(
                    value = query,
                    onValueChange = { query = it },
                    label = { Text("Search") },
                    modifier = Modifier.fillMaxWidth(),
                    singleLine = true
                )
                Spacer(Modifier.height(8.dp))
                LazyColumn {
                    items(filtered, key = { "${it.number}_${it.name}" }) { pokemon ->
                        Row(
                            modifier = Modifier
                                .fillMaxWidth()
                                .clickable { onPick(pokemon) }
                                .padding(vertical = 8.dp),
                            verticalAlignment = Alignment.CenterVertically
                        ) {
                            AsyncImage(
                                model = pokemon.spriteUrl,
                                contentDescription = pokemon.name,
                                modifier = Modifier.size(44.dp)
                            )
                            Spacer(Modifier.width(10.dp))
                            Column {
                                Text(pokemon.name, fontWeight = FontWeight.SemiBold)
                                Row(horizontalArrangement = Arrangement.spacedBy(4.dp)) {
                                    TypeBadge(pokemon.primaryType)
                                    pokemon.secondaryType?.let { TypeBadge(it) }
                                }
                            }
                        }
                        HorizontalDivider(thickness = 0.5.dp)
                    }
                }
            }
        }
    }
}
