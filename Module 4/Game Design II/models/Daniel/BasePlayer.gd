extends KinematicBody
class_name BasePlayer

const initial_health = 100;

const base_speed = 6.0;
const jump_speed = 6;
const crouch_time = 20;

const gravity_strength = 25;
const gravity = Vector3.DOWN * 17.5;

const height = 1.75;
const crouch_height = 1.5;

var Bullet = load("res://models/Daniel/Bullet.tscn");
var speed = base_speed;
var jumping = false;
var velocity = Vector3();
var health = initial_health;

#onready var Model = $MeshInstance;
onready var Hitbox = $CollisionShape;
onready var BulletPos = $MeshInstance/Eye/Pivot/BulletPosition;

### === Movement === ###

func handle_movement(delta):
	velocity += gravity * delta;
	
	var y_vel = reset_movement();
	speed = _handle_movement_speed();
	velocity += _handle_direction(Vector3()) * speed;
	velocity.y = y_vel;
	jumping = false;
	
	_handle_just_jump();
	
	velocity = move_and_slide(velocity, Vector3.UP, true);
	if is_on_floor() and jumping:
		velocity.y = jump_speed;

# Returns previous y velocity
func reset_movement():
	var y_vel = velocity.y;
	velocity = Vector3();
	speed = base_speed;
	return y_vel;

# Virtual Vector3
func _handle_direction(direction: Vector3):	return direction;

# Virtual void
func _handle_just_jump(): pass;

# Moves direction accoridng to directionString: "forward" | "backward" | "left" | "right", and returns direction
func move(directionString: String):
	var direction = Vector3();
	
	if directionString == "forward":
		direction += -BulletPos.global_transform.basis.z;
	if directionString == "backward":
		direction += BulletPos.global_transform.basis.z;
	if directionString == "left":
		direction += -BulletPos.global_transform.basis.x;
	if directionString == "right":
		direction += BulletPos.global_transform.basis.x;
	
	direction = direction.normalized();
	return direction;

### === Speed === ###

# Virtual Float
func _handle_movement_speed(): return speed;

# Adjusts speed to spint_speed and returns it
func sprint(): return speed * 1.75;

# Adjusts speed to crouch_speed and returns it
func crouch(): return speed / 1.75

### === Damage Related === ###

# Subtracts incoming damage from health and removes player from game if health <= 0
func take_damage(damage: int):
	health -= damage;
	
	if health <= 0: queue_free();

# Creates instance of Bullet and "shoots" from BulletPos
func shoot():
	var bullet = Bullet.instance();
	bullet.set_parent(self);
#	print(str(name, ": ", BulletPos.global_transform))
	bullet.start(BulletPos.global_transform);
	get_parent().add_child(bullet);
