extends KinematicBody

# https://www.youtube.com/watch?v=ickZ_Genr7A&list=PLsk-HSGFjnaFwmOFrfD4gQQqvgvEUielY&index=3

const base_speed = 4.0;
const jump_speed = 6;
const gravity_strength = 25;
const gravity = Vector3.DOWN * 15;

var Bullet = preload("res://models/Daniel/Bullet.tscn");
var mouse_sensitivity = 0.002 # radians/pixel
var speed = base_speed;
var jumping = false;
var velocity = Vector3();
var crouching_transform = transform.translated(Vector3(0, -.25, 0));

onready var POV = $Pivot/Camera

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
	if Input.is_action_pressed("sprint"):
		speed *= 2;
	if Input.is_action_pressed("crouch"):
		speed /= 2;

# Mouse movement & shooting
func _unhandled_input(event):
	if event is InputEventMouseMotion and Input.get_mouse_mode() == Input.MOUSE_MODE_CAPTURED:
		rotate_y(-event.relative.x * mouse_sensitivity); # View Left/Right
		$Pivot.rotate_z(-event.relative.y * mouse_sensitivity); # View Up/Down
		$Pivot.rotation.z = clamp($Pivot.rotation.z, -1.75, 1.75) # Don't break your neck
	
	if event.is_action_pressed("shoot"):
		var bullet = Bullet.instance();
		bullet.start($"Pivot/Bullet Position".global_transform);
		get_parent().add_child(bullet);