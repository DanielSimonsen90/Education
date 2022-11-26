extends StaticBody

signal baseplayer_left_map(baseplayer);

func _on_Area_body_exited(body):
	if body.is_in_group("BasePlayer"):
		print(str(body.name, " left the map border"));
		emit_signal("baseplayer_left_map", body);