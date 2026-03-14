package com.poke.app.data

/**
 * Type effectiveness matrix: attacking type vs defending type.
 * Values: 0.0 = immune, 0.5 = not very effective, 1.0 = normal, 2.0 = super effective
 */
object TypeEffectiveness {
    // Row = attacking type, Column = defending type (both in PokemonType.ordinal order)
    private val chart: Array<FloatArray> = arrayOf(
        // Normal vs [Normal,Fighting,Flying,Poison,Ground,Rock,Bug,Ghost,Steel,Fire,Water,Grass,Electric,Psychic,Ice,Dragon,Dark,Fairy]
        floatArrayOf(1f, 1f, 1f, 1f, 1f, .5f, 1f, 0f, .5f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f),
        // Fighting
        floatArrayOf(2f, 1f, .5f, .5f, 1f, 2f, .5f, 0f, 2f, 1f, 1f, 1f, 1f, .5f, 2f, 1f, 2f, .5f),
        // Flying
        floatArrayOf(1f, 2f, 1f, 1f, 1f, .5f, 2f, 1f, .5f, 1f, 1f, 2f, .5f, 1f, 1f, 1f, 1f, 1f),
        // Poison
        floatArrayOf(1f, 1f, 1f, .5f, .5f, .5f, 1f, .5f, 0f, 1f, 1f, 2f, 1f, 1f, 1f, 1f, 1f, 2f),
        // Ground
        floatArrayOf(1f, 1f, 0f, 2f, 1f, 2f, .5f, 1f, 2f, 2f, 1f, .5f, 2f, 1f, 1f, 1f, 1f, 1f),
        // Rock
        floatArrayOf(1f, .5f, 2f, 1f, .5f, 1f, 2f, 1f, .5f, 2f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 1f),
        // Bug
        floatArrayOf(1f, .5f, .5f, .5f, 1f, 1f, 1f, .5f, .5f, .5f, 1f, 2f, 1f, 2f, 1f, 1f, 2f, .5f),
        // Ghost
        floatArrayOf(0f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, .5f, 1f),
        // Steel
        floatArrayOf(1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, .5f, .5f, .5f, 1f, .5f, 1f, 2f, 1f, 1f, 2f),
        // Fire
        floatArrayOf(1f, 1f, 1f, 1f, 1f, .5f, 2f, 1f, 2f, .5f, .5f, 2f, 1f, 1f, 2f, .5f, 1f, 1f),
        // Water
        floatArrayOf(1f, 1f, 1f, 1f, 2f, 2f, 1f, 1f, 1f, 2f, .5f, .5f, 1f, 1f, 1f, .5f, 1f, 1f),
        // Grass
        floatArrayOf(1f, 1f, .5f, .5f, 2f, 2f, .5f, 1f, .5f, .5f, 2f, .5f, 1f, 1f, 1f, .5f, 1f, 1f),
        // Electric
        floatArrayOf(1f, 1f, 2f, 1f, 0f, 1f, 1f, 1f, 1f, 1f, 2f, .5f, .5f, 1f, 1f, .5f, 1f, 1f),
        // Psychic
        floatArrayOf(1f, 2f, 1f, 2f, 1f, 1f, 1f, 1f, .5f, 1f, 1f, 1f, 1f, .5f, 1f, 1f, 0f, 1f),
        // Ice
        floatArrayOf(1f, 1f, 2f, 1f, 2f, 1f, 1f, 1f, .5f, .5f, .5f, 2f, 1f, 1f, .5f, 2f, 1f, 1f),
        // Dragon
        floatArrayOf(1f, 1f, 1f, 1f, 1f, 1f, 1f, 1f, .5f, 1f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 0f),
        // Dark
        floatArrayOf(1f, .5f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, 1f, 1f, 1f, 2f, 1f, 1f, .5f, .5f),
        // Fairy
        floatArrayOf(1f, 2f, 1f, .5f, 1f, 1f, 1f, 1f, .5f, .5f, 1f, 1f, 1f, 1f, 1f, 2f, 2f, 1f)
    )

    fun getEffectiveness(attacking: PokemonType, defending: PokemonType): Float {
        return chart[attacking.ordinal][defending.ordinal]
    }

    fun getCombinedEffectiveness(attacking: PokemonType, type1: PokemonType, type2: PokemonType?): Float {
        val e1 = getEffectiveness(attacking, type1)
        val e2 = if (type2 != null) getEffectiveness(attacking, type2) else 1f
        return e1 * e2
    }
}
