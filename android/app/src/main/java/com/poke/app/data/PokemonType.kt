package com.poke.app.data

enum class PokemonType {
    Normal, Fighting, Flying, Poison, Ground, Rock, Bug, Ghost, Steel,
    Fire, Water, Grass, Electric, Psychic, Ice, Dragon, Dark, Fairy;

    fun displayName(): String = name
}
