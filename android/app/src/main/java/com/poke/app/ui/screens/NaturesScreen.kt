package com.poke.app.ui.screens

import androidx.compose.foundation.horizontalScroll
import androidx.compose.foundation.layout.*
import androidx.compose.foundation.rememberScrollState
import androidx.compose.foundation.verticalScroll
import androidx.compose.material3.*
import androidx.compose.runtime.*
import androidx.compose.ui.Alignment
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.Color
import androidx.compose.ui.text.font.FontWeight
import androidx.compose.ui.text.style.TextAlign
import androidx.compose.ui.unit.dp
import androidx.compose.ui.unit.sp
import com.poke.app.data.GameData

@Composable
fun NaturesScreen() {
    val statColor = mapOf(
        "Attack" to Color(0xFFEF5350),
        "Defense" to Color(0xFF42A5F5),
        "Sp. Atk" to Color(0xFFAB47BC),
        "Sp. Def" to Color(0xFF26A69A),
        "Speed" to Color(0xFFFF7043)
    )

    Column(
        modifier = Modifier
            .fillMaxSize()
            .verticalScroll(rememberScrollState())
    ) {
        Text(
            "All 25 Natures",
            style = MaterialTheme.typography.titleLarge,
            modifier = Modifier.padding(16.dp),
            fontWeight = FontWeight.Bold
        )
        Text(
            "Green = increased stat (+10%), Red = decreased stat (−10%)",
            fontSize = 12.sp,
            color = MaterialTheme.colorScheme.onSurface.copy(alpha = 0.6f),
            modifier = Modifier.padding(horizontal = 16.dp, vertical = 4.dp)
        )
        // Table header
        Row(
            modifier = Modifier
                .fillMaxWidth()
                .padding(horizontal = 8.dp, vertical = 4.dp)
        ) {
            Text("Nature", modifier = Modifier.width(90.dp), fontWeight = FontWeight.Bold, fontSize = 13.sp)
            Text("+", modifier = Modifier.width(80.dp), fontWeight = FontWeight.Bold, fontSize = 13.sp, color = Color(0xFF2E7D32))
            Text("−", modifier = Modifier.width(80.dp), fontWeight = FontWeight.Bold, fontSize = 13.sp, color = Color(0xFFC62828))
        }
        HorizontalDivider()
        GameData.natures.forEach { nature ->
            val incColor = if (nature.increased != null) Color(0xFFE8F5E9) else Color.Transparent
            val rowBg = incColor
            Row(
                modifier = Modifier
                    .fillMaxWidth()
                    .padding(horizontal = 8.dp, vertical = 3.dp),
                verticalAlignment = Alignment.CenterVertically
            ) {
                Text(
                    nature.name,
                    modifier = Modifier.width(90.dp),
                    fontSize = 13.sp,
                    fontWeight = if (nature.increased == null) FontWeight.Normal else FontWeight.SemiBold
                )
                Text(
                    nature.increased ?: "—",
                    modifier = Modifier.width(80.dp),
                    fontSize = 13.sp,
                    color = if (nature.increased != null) Color(0xFF2E7D32) else MaterialTheme.colorScheme.onSurface.copy(alpha = 0.4f)
                )
                Text(
                    nature.decreased ?: "—",
                    modifier = Modifier.width(80.dp),
                    fontSize = 13.sp,
                    color = if (nature.decreased != null) Color(0xFFC62828) else MaterialTheme.colorScheme.onSurface.copy(alpha = 0.4f)
                )
            }
            HorizontalDivider(thickness = 0.5.dp)
        }
    }
}
