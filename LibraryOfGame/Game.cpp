#include "pch.h"
#include "Game.h"
#include <cstdlib>

double Game::chance()
{
	return (double)rand() / (double)RAND_MAX;
}
