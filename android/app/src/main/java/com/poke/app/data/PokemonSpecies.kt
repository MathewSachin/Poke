package com.poke.app.data

data class PokemonSpecies(
    val number: Int,
    val name: String,
    val primaryType: PokemonType,
    val secondaryType: PokemonType? = null,
    val hp: Int,
    val attack: Int,
    val defense: Int,
    val spAttack: Int,
    val spDefense: Int,
    val speed: Int,
    val ability1: String,
    val ability2: String? = null,
    val hiddenAbility: String? = null,
    val learnset: List<String> = emptyList()
) {
    val baseStatTotal get() = hp + attack + defense + spAttack + spDefense + speed
    val spriteUrl get() = "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/$number.png"
}
