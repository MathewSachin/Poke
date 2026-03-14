package com.poke.app.ui.components

import androidx.compose.foundation.layout.Arrangement
import androidx.compose.foundation.layout.Row
import androidx.compose.foundation.layout.fillMaxWidth
import androidx.compose.foundation.layout.height
import androidx.compose.material3.LinearProgressIndicator
import androidx.compose.material3.MaterialTheme
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp

@Composable
fun StatBar(label: String, value: Int, maxValue: Int = 255, modifier: Modifier = Modifier) {
    val ratio = value.toFloat() / maxValue
    val color = when {
        ratio < 0.3f -> Color(0xFFE53935)
        ratio < 0.6f -> Color(0xFFFFA726)
        else -> Color(0xFF43A047)
    }
    Row(
        modifier = modifier.fillMaxWidth(),
        verticalAlignment = Alignment.CenterVertically,
        horizontalArrangement = Arrangement.spacedBy(8.dp)
    ) {
        Text(
            text = label,
            modifier = Modifier.weight(0.35f),
            fontSize = 12.sp,
            color = MaterialTheme.colorScheme.onSurface.copy(alpha = 0.7f)
        )
        Text(
            text = value.toString(),
            modifier = Modifier.weight(0.12f),
            fontSize = 12.sp,
            fontWeight = FontWeight.Bold
        )
        LinearProgressIndicator(
            progress = { ratio },
            modifier = Modifier.weight(0.53f).height(8.dp),
            color = color,
            trackColor = color.copy(alpha = 0.2f)
        )
    }
}
