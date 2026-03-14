package com.poke.app.data

enum class MoveKind { Physical, Special, Status }

data class MoveInfo(
    val name: String,
    val type: PokemonType,
    val kind: MoveKind,
    val power: Int?,
    val accuracy: Int?,
    val pp: Int,
    val description: String = "",
    val priority: Int = 0
)
