extends BasePlayer
class_name Player
#extends load("res://models/Daniel/BasePlayer.gd")

var mouse_sensitivity = 0.002 # radians/pixel

onready var Pivot = $MeshInstance/Eye/Pivot;
onready var POV = $MeshInstance/Eye/Pivot/Camera;

func _physics_process(delta):
	velocity += gravity * delta;
	
	get_input();
	
	velocity = move_and_slide(velocity, Vector3.UP, true);
	if is_on_floor() and jumping: 
		velocity.y = jump_speed;
	
func get_input():
	var y_vel = velocity.y;
	velocity = Vector3();
	speed = base_speed;
	transform = transform.translated(Vector3(0, 0, 0));
	
	handle_movement();
	
	velocity.y = y_vel;
	jumping = false;
	
	if Input.is_action_just_pressed("jump"):
		jumping = true

func handle_movement():
	handle_movement_speed();
	
	var direction = Vector3();
	if Input.is_action_pressed("move_forward"):
		direction += -POV.global_transform.basis.z;
	if Input.is_action_pressed("move_backward"):
		direction += POV.global_transform.basis.z;
	if Input.is_action_pressed("move_left"):
		direction += -POV.global_transform.basis.x;
	if Input.is_action_pressed("move_right"):
		direction += POV.global_transform.basis.x;
	direction = direction.normalized();
	
	velocity += direction * speed;

func handle_movement_speed():
	if Input.is_action_pressed("sprint"): speed *= 2;
	if Input.is_action_pressed("crouch"): speed /= 2;

# Mouse movement & shooting
func _unhandled_input(event):
	if event is InputEventMouseMotion and Input.get_mouse_mode() == Input.MOUSE_MODE_CAPTURED:
		on_mouse_move(event);
	
	if event.is_action_pressed("shoot"): shoot();

func on_mouse_move(event):
		rotate_y(-event.relative.x * mouse_sensitivity); # View Left/Right
		Pivot.rotate_x(-event.relative.y * mouse_sensitivity); # View Up/Down
		Pivot.rotation.x = clamp(Pivot.rotation.x, -1.75, 1.75) # Don't break your neck