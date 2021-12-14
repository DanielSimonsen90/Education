extends Spatial

func _ready():
	capture_mouse(false);

func _input(event):
	if event.is_action_pressed("ui_cancel"):
		capture_mouse(true);
		
	if event.is_action_pressed("shoot"):
		if Input.get_mouse_mode() == Input.MOUSE_MODE_VISIBLE:
			capture_mouse(false);
			get_tree().set_input_as_handled();
			
func capture_mouse(visible):
	if visible: 
		Input.set_mouse_mode(Input.MOUSE_MODE_VISIBLE);
	else:
		Input.set_mouse_mode(Input.MOUSE_MODE_CAPTURED);
	