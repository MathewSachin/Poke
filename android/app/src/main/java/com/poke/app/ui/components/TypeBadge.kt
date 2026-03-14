package com.poke.app.ui.components

import androidx.compose.foundation.background
import androidx.compose.foundation.layout.Box
import androidx.compose.foundation.layout.padding
import androidx.compose.foundation.shape.RoundedCornerShape
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import com.poke.app.data.PokemonType
import com.poke.app.ui.theme.pokemonTypeColor

@Composable
fun TypeBadge(type: PokemonType, modifier: Modifier = Modifier) {
    val bgColor = pokemonTypeColor(type)
    val textColor = if (type == PokemonType.Electric || type == PokemonType.Ground ||
        type == PokemonType.Normal || type == PokemonType.Ice) Color.Black.copy(alpha = 0.8f)
    else Color.White
    Box(
        modifier = modifier
            .background(bgColor, RoundedCornerShape(12.dp))
            .padding(horizontal = 10.dp, vertical = 3.dp),
        contentAlignment = Alignment.Center
    ) {
        Text(
            text = type.displayName(),
            color = textColor,
            fontSize = 12.sp,
            fontWeight = FontWeight.Bold
        )
    }
}
