package com.poke.app.ui.screens

import androidx.compose.foundation.clickable
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.LazyRow
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.draw.clip
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import coil.compose.AsyncImage
import com.poke.app.data.GameData
import com.poke.app.data.PokemonSpecies
import com.poke.app.data.PokemonType
import com.poke.app.ui.components.TypeBadge

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun PokedexScreen(onPokemonClick: (String) -> Unit) {
    var query by remember { mutableStateOf("") }
    var selectedType by remember { mutableStateOf<PokemonType?>(null) }

    val filtered = remember(query, selectedType) {
        GameData.pokemon.filter { p ->
            (query.isBlank() || p.name.contains(query, ignoreCase = true) ||
                    p.number.toString().contains(query)) &&
                    (selectedType == null || p.primaryType == selectedType || p.secondaryType == selectedType)
        }
    }

    Column(modifier = Modifier.fillMaxSize()) {
        OutlinedTextField(
            value = query,
            onValueChange = { query = it },
            label = { Text("Search Pokémon") },
            modifier = Modifier
                .fillMaxWidth()
                .padding(horizontal = 12.dp, vertical = 8.dp),
            singleLine = true
        )

        LazyRow(
            contentPadding = PaddingValues(horizontal = 12.dp),
            horizontalArrangement = Arrangement.spacedBy(6.dp),
            modifier = Modifier.padding(bottom = 8.dp)
        ) {
            item {
                FilterChip(
                    selected = selectedType == null,
                    onClick = { selectedType = null },
                    label = { Text("All") }
                )
            }
            items(PokemonType.values()) { type ->
                FilterChip(
                    selected = selectedType == type,
                    onClick = { selectedType = if (selectedType == type) null else type },
                    label = { Text(type.displayName()) }
                )
            }
        }

        LazyColumn(
            contentPadding = PaddingValues(horizontal = 12.dp, vertical = 4.dp),
            verticalArrangement = Arrangement.spacedBy(8.dp)
        ) {
            items(filtered, key = { "${it.number}_${it.name}" }) { pokemon ->
                PokemonCard(pokemon = pokemon, onClick = { onPokemonClick(pokemon.name) })
            }
        }
    }
}

@Composable
fun PokemonCard(pokemon: PokemonSpecies, onClick: () -> Unit) {
    Card(
        modifier = Modifier
            .fillMaxWidth()
            .clickable(onClick = onClick),
        elevation = CardDefaults.cardElevation(defaultElevation = 2.dp)
    ) {
        Row(
            modifier = Modifier.padding(8.dp),
            verticalAlignment = Alignment.CenterVertically
        ) {
            AsyncImage(
                model = pokemon.spriteUrl,
                contentDescription = pokemon.name,
                modifier = Modifier
                    .size(64.dp)
                    .clip(RoundedCornerShape(8.dp))
            )
            Spacer(Modifier.width(12.dp))
            Column(modifier = Modifier.weight(1f)) {
                Row(verticalAlignment = Alignment.CenterVertically) {
                    Text(
                        text = "#${String.format("%03d", pokemon.number)}",
                        fontSize = 12.sp,
                        color = MaterialTheme.colorScheme.onSurface.copy(alpha = 0.6f)
                    )
                    Spacer(Modifier.width(6.dp))
                    Text(
                        text = pokemon.name,
                        fontWeight = FontWeight.Bold,
                        fontSize = 16.sp
                    )
                }
                Spacer(Modifier.height(4.dp))
                Row(horizontalArrangement = Arrangement.spacedBy(4.dp)) {
                    TypeBadge(pokemon.primaryType)
                    pokemon.secondaryType?.let { TypeBadge(it) }
                }
            }
            Text(
                text = "BST\n${pokemon.baseStatTotal}",
                fontSize = 12.sp,
                fontWeight = FontWeight.Bold,
                color = MaterialTheme.colorScheme.primary
            )
        }
    }
}
