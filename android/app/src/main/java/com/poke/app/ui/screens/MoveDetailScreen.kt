package com.poke.app.ui.screens

import androidx.compose.foundation.layout.*
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.automirrored.filled.ArrowBack
import androidx.compose.material3.*
import androidx.compose.runtime.Composable
import androidx.compose.runtime.remember
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import com.poke.app.data.GameData
import com.poke.app.ui.components.TypeBadge

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun MoveDetailScreen(moveName: String, onBack: () -> Unit) {
    val move = remember(moveName) { GameData.moves.find { it.name == moveName } }

    Scaffold(
        topBar = {
            TopAppBar(
                title = { Text(move?.name ?: "Move Detail") },
                navigationIcon = {
                    IconButton(onClick = onBack) {
                        Icon(Icons.AutoMirrored.Filled.ArrowBack, contentDescription = "Back")
                    }
                }
            )
        }
    ) { padding ->
        if (move == null) {
            Box(Modifier.fillMaxSize().padding(padding), contentAlignment = Alignment.Center) {
                Text("Move not found")
            }
            return@Scaffold
        }
        Column(
            modifier = Modifier
                .fillMaxSize()
                .padding(padding)
                .verticalScroll(rememberScrollState())
                .padding(16.dp)
        ) {
            Text(move.name, fontSize = 24.sp, fontWeight = FontWeight.Bold)
            Spacer(Modifier.height(8.dp))
            Row(horizontalArrangement = Arrangement.spacedBy(8.dp)) {
                TypeBadge(move.type)
                KindBadge(move.kind)
            }
            Spacer(Modifier.height(16.dp))
            StatRow("Power", move.power?.toString() ?: "—")
            StatRow("Accuracy", if (move.accuracy != null) "${move.accuracy}%" else "—")
            StatRow("PP", move.pp.toString())
            if (move.priority != 0) StatRow("Priority", move.priority.toString())
            if (move.description.isNotEmpty()) {
                Spacer(Modifier.height(16.dp))
                Text("Description", fontWeight = FontWeight.Bold, fontSize = 16.sp)
                Spacer(Modifier.height(4.dp))
                Text(move.description, fontSize = 14.sp, lineHeight = 20.sp)
            }
        }
    }
}

@Composable
private fun StatRow(label: String, value: String) {
    Row(
        modifier = Modifier
            .fillMaxWidth()
            .padding(vertical = 4.dp),
        horizontalArrangement = Arrangement.SpaceBetween
    ) {
        Text(label, color = MaterialTheme.colorScheme.onSurface.copy(alpha = 0.6f))
        Text(value, fontWeight = FontWeight.SemiBold)
    }
    HorizontalDivider(thickness = 0.5.dp)
}
