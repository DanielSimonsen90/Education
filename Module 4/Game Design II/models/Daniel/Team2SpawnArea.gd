extends BaseSpawnArea
class_name Team2

func _spawn_players(): return max_players + 1;

func _get_new_player(): return load("res://models/Daniel/Enemy.tscn")
