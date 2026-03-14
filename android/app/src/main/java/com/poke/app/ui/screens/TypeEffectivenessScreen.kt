package com.poke.app.ui.screens

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.lazy.LazyRow
import androidx.compose.foundation.lazy.items
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import com.poke.app.data.PokemonType
import com.poke.app.data.TypeEffectiveness
import com.poke.app.ui.components.TypeBadge

@OptIn(ExperimentalLayoutApi::class)
@Composable
fun TypeEffectivenessScreen() {
    var attackerType by remember { mutableStateOf<PokemonType?>(null) }
    var defenderType1 by remember { mutableStateOf<PokemonType?>(null) }
    var defenderType2 by remember { mutableStateOf<PokemonType?>(null) }

    Column(
        modifier = Modifier
            .fillMaxSize()
            .verticalScroll(rememberScrollState())
            .padding(16.dp)
    ) {
        Text("Type Effectiveness Calculator", style = MaterialTheme.typography.titleLarge, fontWeight = FontWeight.Bold)
        Spacer(Modifier.height(16.dp))

        Text("Attacking Type", fontWeight = FontWeight.SemiBold)
        Spacer(Modifier.height(6.dp))
        TypeSelector(selected = attackerType, onSelect = { attackerType = it })

        Spacer(Modifier.height(16.dp))
        Text("Defending Type 1", fontWeight = FontWeight.SemiBold)
        Spacer(Modifier.height(6.dp))
        TypeSelector(selected = defenderType1, onSelect = { defenderType1 = it })

        Spacer(Modifier.height(16.dp))
        Text("Defending Type 2 (optional)", fontWeight = FontWeight.SemiBold)
        Spacer(Modifier.height(6.dp))
        TypeSelectorOptional(selected = defenderType2, onSelect = { defenderType2 = it })

        if (attackerType != null && defenderType1 != null) {
            Spacer(Modifier.height(24.dp))
            val effectiveness = TypeEffectiveness.getCombinedEffectiveness(attackerType!!, defenderType1!!, defenderType2)
            EffectivenessResult(attackerType!!, defenderType1!!, defenderType2, effectiveness)
        }

        Spacer(Modifier.height(24.dp))
        if (attackerType != null) {
            Text("${attackerType!!.displayName()} attacks all types:", fontWeight = FontWeight.SemiBold)
            Spacer(Modifier.height(8.dp))
            AllTypeChart(attackerType!!)
        }
    }
}

@OptIn(ExperimentalLayoutApi::class)
@Composable
private fun TypeSelector(selected: PokemonType?, onSelect: (PokemonType) -> Unit) {
    FlowRow(horizontalArrangement = Arrangement.spacedBy(4.dp), verticalArrangement = Arrangement.spacedBy(4.dp)) {
        PokemonType.values().forEach { type ->
            val isSelected = selected == type
            Box(
                modifier = Modifier
                    .background(
                        if (isSelected) MaterialTheme.colorScheme.primary
                        else MaterialTheme.colorScheme.surface,
                        androidx.compose.foundation.shape.RoundedCornerShape(20.dp)
                    )
                    .padding(2.dp)
            ) {
                TypeBadge(
                    type = type,
                    modifier = Modifier.clickableIf { onSelect(type) }
                )
            }
        }
    }
}

@OptIn(ExperimentalLayoutApi::class, ExperimentalMaterial3Api::class)
@Composable
private fun TypeSelectorOptional(selected: PokemonType?, onSelect: (PokemonType?) -> Unit) {
    FlowRow(horizontalArrangement = Arrangement.spacedBy(4.dp), verticalArrangement = Arrangement.spacedBy(4.dp)) {
        FilterChip(selected = selected == null, onClick = { onSelect(null) }, label = { Text("None") })
        PokemonType.values().forEach { type ->
            FilterChip(
                selected = selected == type,
                onClick = { onSelect(if (selected == type) null else type) },
                label = { Text(type.displayName()) }
            )
        }
    }
}

@Composable
private fun EffectivenessResult(
    atk: PokemonType, def1: PokemonType, def2: PokemonType?, value: Float
) {
    val label = when (value) {
        0f -> "Immune (0×)"
        0.25f -> "Not very effective (¼×)"
        0.5f -> "Not very effective (½×)"
        1f -> "Normal effectiveness (1×)"
        2f -> "Super effective! (2×)"
        4f -> "Super super effective! (4×)"
        else -> "${value}×"
    }
    val bgColor = when (value) {
        0f -> Color(0xFF424242)
        0.25f, 0.5f -> Color(0xFF1565C0)
        1f -> Color(0xFF388E3C)
        2f -> Color(0xFFD32F2F)
        4f -> Color(0xFFB71C1C)
        else -> Color.Gray
    }
    Card(colors = CardDefaults.cardColors(containerColor = bgColor)) {
        Row(
            modifier = Modifier
                .fillMaxWidth()
                .padding(16.dp),
            verticalAlignment = Alignment.CenterVertically,
            horizontalArrangement = Arrangement.SpaceBetween
        ) {
            Column {
                Row(horizontalArrangement = Arrangement.spacedBy(4.dp)) {
                    TypeBadge(atk)
                    Text("→", color = Color.White, fontWeight = FontWeight.Bold)
                    TypeBadge(def1)
                    def2?.let { TypeBadge(it) }
                }
            }
            Text(label, color = Color.White, fontWeight = FontWeight.Bold, fontSize = 16.sp)
        }
    }
}

@Composable
private fun AllTypeChart(attacker: PokemonType) {
    PokemonType.values().forEach { defender ->
        val eff = TypeEffectiveness.getEffectiveness(attacker, defender)
        if (eff != 1f) {
            val color = when (eff) {
                0f -> Color(0xFF616161)
                0.5f -> Color(0xFF1E88E5)
                2f -> Color(0xFFE53935)
                else -> Color.Gray
            }
            Row(
                modifier = Modifier
                    .fillMaxWidth()
                    .padding(vertical = 2.dp),
                verticalAlignment = Alignment.CenterVertically,
                horizontalArrangement = Arrangement.spacedBy(8.dp)
            ) {
                TypeBadge(defender)
                Text(
                    when (eff) { 0f -> "Immune (0×)"; 0.5f -> "½×"; 2f -> "2×"; else -> "${eff}×" },
                    color = color,
                    fontWeight = FontWeight.Bold
                )
            }
        }
    }
}

private fun Modifier.clickableIf(onClick: () -> Unit): Modifier =
    this.then(androidx.compose.foundation.clickable(onClick = onClick))
