package com.poke.app.ui.screens

import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyColumn
import androidx.compose.foundation.lazy.items
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Modifier
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import com.poke.app.data.GameData

@OptIn(ExperimentalMaterial3Api::class)
@Composable
fun AbilitiesScreen() {
    var query by remember { mutableStateOf("") }

    val filtered = remember(query) {
        GameData.abilities.filter { a ->
            query.isBlank() || a.name.contains(query, ignoreCase = true) ||
                    a.description.contains(query, ignoreCase = true)
        }.sortedBy { it.name }
    }

    Column(modifier = Modifier.fillMaxSize()) {
        OutlinedTextField(
            value = query,
            onValueChange = { query = it },
            label = { Text("Search Abilities") },
            modifier = Modifier
                .fillMaxWidth()
                .padding(horizontal = 12.dp, vertical = 8.dp),
            singleLine = true
        )
        Text(
            "${filtered.size} abilities",
            modifier = Modifier.padding(horizontal = 16.dp, vertical = 2.dp),
            fontSize = 12.sp,
            color = MaterialTheme.colorScheme.onSurface.copy(alpha = 0.5f)
        )
        LazyColumn(
            contentPadding = PaddingValues(horizontal = 12.dp, vertical = 4.dp),
            verticalArrangement = Arrangement.spacedBy(6.dp)
        ) {
            items(filtered, key = { it.name }) { ability ->
                Card(
                    modifier = Modifier.fillMaxWidth(),
                    elevation = CardDefaults.cardElevation(defaultElevation = 1.dp)
                ) {
                    Column(modifier = Modifier.padding(12.dp)) {
                        Text(ability.name, fontWeight = FontWeight.Bold, fontSize = 14.sp)
                        if (ability.description.isNotEmpty()) {
                            Spacer(Modifier.height(4.dp))
                            Text(
                                ability.description,
                                fontSize = 12.sp,
                                color = MaterialTheme.colorScheme.onSurface.copy(alpha = 0.75f),
                                lineHeight = 17.sp
                            )
                        }
                    }
                }
            }
        }
    }
}
