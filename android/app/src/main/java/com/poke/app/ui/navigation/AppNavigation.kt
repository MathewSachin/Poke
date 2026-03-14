package com.poke.app.ui.navigation

import android.net.Uri
import androidx.compose.foundation.layout.padding
import androidx.compose.material.icons.Icons
import androidx.compose.material.icons.filled.Groups
import androidx.compose.material.icons.filled.Info
import androidx.compose.material.icons.filled.Pets
import androidx.compose.material.icons.filled.SportsMartialArts
import androidx.compose.material.icons.filled.Star
import androidx.compose.material3.Icon
import androidx.compose.material3.NavigationBar
import androidx.compose.material3.NavigationBarItem
import androidx.compose.material3.Text
import androidx.compose.runtime.Composable
import androidx.compose.runtime.getValue
import androidx.compose.ui.Modifier
import androidx.compose.ui.graphics.vector.ImageVector
import androidx.navigation.NavController
import androidx.navigation.NavDestination.Companion.hierarchy
import androidx.navigation.NavGraph.Companion.findStartDestination
import androidx.navigation.compose.NavHost
import androidx.navigation.compose.composable
import androidx.navigation.compose.currentBackStackEntryAsState
import androidx.navigation.compose.rememberNavController
import com.poke.app.ui.screens.AbilitiesScreen
import com.poke.app.ui.screens.BattleScreen
import com.poke.app.ui.screens.InfoScreen
import com.poke.app.ui.screens.MoveDetailScreen
import com.poke.app.ui.screens.MovesScreen
import com.poke.app.ui.screens.PokedexScreen
import com.poke.app.ui.screens.PokemonDetailScreen
import com.poke.app.ui.screens.TeamBuilderScreen

sealed class Screen(val route: String, val label: String, val icon: ImageVector) {
    object Pokedex : Screen("pokedex", "Pokédex", Icons.Filled.Pets)
    object Moves : Screen("moves", "Moves", Icons.Filled.SportsMartialArts)
    object Abilities : Screen("abilities", "Abilities", Icons.Filled.Star)
    object Info : Screen("info", "Info", Icons.Filled.Info)
    object Team : Screen("team", "Team", Icons.Filled.Groups)
}

val bottomNavItems = listOf(
    Screen.Pokedex,
    Screen.Moves,
    Screen.Abilities,
    Screen.Info,
    Screen.Team,
)

@Composable
fun AppNavigation() {
    val navController = rememberNavController()
    androidx.compose.material3.Scaffold(
        bottomBar = { BottomNav(navController) }
    ) { padding ->
        NavHost(
            navController = navController,
            startDestination = Screen.Pokedex.route,
            modifier = Modifier.padding(padding)
        ) {
            composable(Screen.Pokedex.route) {
                PokedexScreen(
                    onPokemonClick = { pokemonName ->
                        navController.navigate("pokemon_detail/${Uri.encode(pokemonName)}")
                    }
                )
            }
            composable("pokemon_detail/{name}") { backStack ->
                val name = backStack.arguments?.getString("name") ?: ""
                PokemonDetailScreen(pokemonName = name, onBack = { navController.popBackStack() })
            }
            composable(Screen.Moves.route) {
                MovesScreen(
                    onMoveClick = { moveName ->
                        navController.navigate("move_detail/${Uri.encode(moveName)}")
                    }
                )
            }
            composable("move_detail/{name}") { backStack ->
                val name = backStack.arguments?.getString("name") ?: ""
                MoveDetailScreen(moveName = name, onBack = { navController.popBackStack() })
            }
            composable(Screen.Abilities.route) {
                AbilitiesScreen()
            }
            composable(Screen.Info.route) {
                InfoScreen()
            }
            composable(Screen.Team.route) {
                TeamBuilderScreen(
                    onBattleClick = { navController.navigate("battle") }
                )
            }
            composable("battle") {
                BattleScreen(onBack = { navController.popBackStack() })
            }
        }
    }
}

@Composable
fun BottomNav(navController: NavController) {
    val navBackStackEntry by navController.currentBackStackEntryAsState()
    val currentDestination = navBackStackEntry?.destination
    NavigationBar {
        bottomNavItems.forEach { screen ->
            val selected = currentDestination?.hierarchy?.any { it.route == screen.route } == true
            NavigationBarItem(
                icon = { Icon(screen.icon, contentDescription = screen.label) },
                label = { Text(screen.label) },
                selected = selected,
                onClick = {
                    navController.navigate(screen.route) {
                        popUpTo(navController.graph.findStartDestination().id) { saveState = true }
                        launchSingleTop = true
                        restoreState = true
                    }
                }
            )
        }
    }
}
