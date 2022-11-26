extends BasePlayer
class_name Player

var mouse_sensitivity = 0.002 # radians/pixel

onready var Pivot = $MeshInstance/Eye/Pivot;
onready var POV = $MeshInstance/Eye/Pivot/Camera;

func _physics_process(delta):
	handle_movement(delta);

func _handle_movement_speed():
	if Input.is_action_pressed("sprint"): sprint();
	if Input.is_action_pressed("crouch"): crouch();
	return speed;

func _handle_direction(direction: Vector3):
	if Input.is_action_pressed("move_forward"):
		direction += move("forward");
	if Input.is_action_pressed("move_backward"):
		direction += move("backward");
	if Input.is_action_pressed("move_left"):
		direction += move("left");
	if Input.is_action_pressed("move_right"):
		direction += move("right");
	return direction;

func _handle_just_jump():
	if Input.is_action_just_pressed("jump"):
		jumping = true

# Mouse movement & shooting
func _unhandled_input(event):
	if event is InputEventMouseMotion and Input.get_mouse_mode() == Input.MOUSE_MODE_CAPTURED:
		on_mouse_move(event);
	
	if event.is_action_pressed("shoot"): shoot();

func on_mouse_move(event):
	rotate_y(-event.relative.x * mouse_sensitivity); # View Left/Right
	Pivot.rotate_x(-event.relative.y * mouse_sensitivity); # View Up/Down
	Pivot.rotation.x = clamp(Pivot.rotation.x, deg2rad(-100), deg2rad(100)) # Don't break your neck