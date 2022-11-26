extends Spatial

#onready var Team1 = $Team1;
onready var Team2 = $Team2;

func _ready():
	capture_mouse(false);
	$Ground.connect("baseplayer_left_map", self, "on_baseplayer_death");

func _input(event):
	if event.is_action_pressed("ui_cancel"): capture_mouse(true);
	if event.is_action_pressed("shoot"):
		if Input.get_mouse_mode() == Input.MOUSE_MODE_VISIBLE:
			capture_mouse(false);
			get_tree().set_input_as_handled();

func capture_mouse(visible):
	if visible: Input.set_mouse_mode(Input.MOUSE_MODE_VISIBLE);
	else: Input.set_mouse_mode(Input.MOUSE_MODE_CAPTURED);

func on_baseplayer_death(player: BasePlayer):
	if player.is_in_group("Player"): on_player_death();
	elif player.is_in_group("Enemy"): on_enemy_death(player);
	else: print(player.name);
	
	player.take_damage(200);

func on_player_death(): capture_mouse(true);
func on_enemy_death(enemy: Enemy): 
	print(str(enemy.name, " died."));
	Team2.on_player_death();
