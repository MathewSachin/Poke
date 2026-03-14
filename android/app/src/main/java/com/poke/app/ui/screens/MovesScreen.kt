package com.poke.app.ui.screens

import androidx.compose.foundation.background
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
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import com.poke.app.data.GameData
import com.poke.app.data.MoveInfo
import com.poke.app.data.MoveKind
import com.poke.app.data.PokemonType
import com.poke.app.ui.components.TypeBadge

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun MovesScreen(onMoveClick: (String) -> Unit) {
    var query by remember { mutableStateOf("") }
    var selectedType by remember { mutableStateOf<PokemonType?>(null) }
    var selectedKind by remember { mutableStateOf<MoveKind?>(null) }

    val filtered = remember(query, selectedType, selectedKind) {
        GameData.moves.filter { m ->
            (query.isBlank() || m.name.contains(query, ignoreCase = true)) &&
                    (selectedType == null || m.type == selectedType) &&
                    (selectedKind == null || m.kind == selectedKind)
        }.sortedBy { it.name }
    }

    Column(modifier = Modifier.fillMaxSize()) {
        OutlinedTextField(
            value = query,
            onValueChange = { query = it },
            label = { Text("Search Moves") },
            modifier = Modifier.fillMaxWidth().padding(horizontal = 12.dp, vertical = 8.dp),
            singleLine = true
        )
        Row(
            modifier = Modifier.padding(horizontal = 12.dp, vertical = 4.dp),
            horizontalArrangement = Arrangement.spacedBy(6.dp)
        ) {
            FilterChip(selected = selectedKind == null, onClick = { selectedKind = null }, label = { Text("All") })
            MoveKind.values().forEach { kind ->
                FilterChip(
                    selected = selectedKind == kind,
                    onClick = { selectedKind = if (selectedKind == kind) null else kind },
                    label = { Text(kind.name) }
                )
            }
        }
        LazyRow(
            contentPadding = PaddingValues(horizontal = 12.dp),
            horizontalArrangement = Arrangement.spacedBy(6.dp),
            modifier = Modifier.padding(bottom = 8.dp)
        ) {
            item { FilterChip(selected = selectedType == null, onClick = { selectedType = null }, label = { Text("All") }) }
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
            verticalArrangement = Arrangement.spacedBy(6.dp)
        ) {
            items(filtered, key = { it.name }) { move ->
                MoveCard(move = move, onClick = { onMoveClick(move.name) })
            }
        }
    }
}

@Composable
fun MoveCard(move: MoveInfo, onClick: () -> Unit) {
    Card(
        modifier = Modifier.fillMaxWidth().clickable(onClick = onClick),
        elevation = CardDefaults.cardElevation(defaultElevation = 2.dp)
    ) {
        Row(modifier = Modifier.padding(10.dp), verticalAlignment = Alignment.CenterVertically) {
            Column(modifier = Modifier.weight(1f)) {
                Text(move.name, fontWeight = FontWeight.Bold, fontSize = 14.sp)
                Spacer(Modifier.height(4.dp))
                Row(horizontalArrangement = Arrangement.spacedBy(4.dp)) {
                    TypeBadge(move.type)
                    KindBadge(move.kind)
                }
            }
            Column(horizontalAlignment = Alignment.End) {
                Text("Pwr: ${move.power ?: "—"}", fontSize = 12.sp)
                Text("Acc: ${if (move.accuracy != null) "${move.accuracy}%" else "—"}", fontSize = 12.sp)
                Text("PP: ${move.pp}", fontSize = 12.sp)
            }
        }
    }
}

@Composable
fun KindBadge(kind: MoveKind) {
    val color = when (kind) {
        MoveKind.Physical -> Color(0xFFC03028)
        MoveKind.Special -> Color(0xFF6890F0)
        MoveKind.Status -> Color(0xFF787878)
    }
    Box(
        modifier = Modifier
            .background(color, RoundedCornerShape(12.dp))
            .padding(horizontal = 8.dp, vertical = 3.dp)
    ) {
        Text(text = kind.name, color = Color.White, fontSize = 11.sp, fontWeight = FontWeight.Bold)
    }
}
