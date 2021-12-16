extends Area
class_name BaseSpawnArea

var max_players = 1;
var player_cap = 2;
var alive_players = max_players;

onready var SpawnArea: Area = $Safezone;

func _ready():
	spawn_players();

func _physics_process(delta):
	if Input.is_action_just_pressed("manual_spawn_enemy"):
		SpawnArea.add_child(_get_new_player().instance())

func spawn_players():
	max_players = _spawn_players();
	if max_players > player_cap: max_players = player_cap
	
	alive_players = max_players;
	
	for player in max_players:
		SpawnArea.add_child(_get_new_player().instance())

# Virtual int
func _spawn_players(): return 1;

func on_player_death():
	alive_players -= 1;
	_on_player_death();
	
	if alive_players <= 0: spawn_players()

# Virtual void
func _on_player_death(): pass;

# Abstract BasePlayer
func _get_new_player(): 
	assert(false)
#	return BasePlayer.new();
