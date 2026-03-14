package com.poke.app.ui.theme

import androidx.compose.ui.graphics.Color
import com.poke.app.data.PokemonType

fun pokemonTypeColor(type: PokemonType): Color = when (type) {
    PokemonType.Normal -> TypeNormal
    PokemonType.Fighting -> TypeFighting
    PokemonType.Flying -> TypeFlying
    PokemonType.Poison -> TypePoison
    PokemonType.Ground -> TypeGround
    PokemonType.Rock -> TypeRock
    PokemonType.Bug -> TypeBug
    PokemonType.Ghost -> TypeGhost
    PokemonType.Steel -> TypeSteel
    PokemonType.Fire -> TypeFire
    PokemonType.Water -> TypeWater
    PokemonType.Grass -> TypeGrass
    PokemonType.Electric -> TypeElectric
    PokemonType.Psychic -> TypePsychic
    PokemonType.Ice -> TypeIce
    PokemonType.Dragon -> TypeDragon
    PokemonType.Dark -> TypeDark
    PokemonType.Fairy -> TypeFairy
}
