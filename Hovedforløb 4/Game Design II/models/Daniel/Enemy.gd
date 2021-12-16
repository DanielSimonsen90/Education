extends BasePlayer
class_name Enemy

enum { IDLE, ALERT }

const turn_speed = 2;

var state = IDLE;
var current_direction = "forward";
var target;

onready var Eyes = $Eyes;
onready var ShootTimer = $ShootTimer

func _physics_process(delta):
	handle_movement(delta);
	
	match state:
		IDLE: on_idle();
		ALERT: on_alert();

func random_true(): return rand_range(0, 2) > 1;

### === Enemy State handling === ###

func on_idle(): pass;
func on_alert():
	Eyes.look_at(target.global_transform.origin, Vector3.UP);
	rotate_y(deg2rad(Eyes.rotation.y * turn_speed * 2 * rand_range(1, 5)))

### === Player entered SightRange === ###

func _on_SightRange_body_entered(body):
	if body.is_in_group("Player"):
		state = ALERT;
		target = body;
		ShootTimer.start();
func _on_SightRange_body_exited(body):
	if not body.is_in_group("Player"): return
	
	state = IDLE;
	ShootTimer.stop();

func _on_ShootTimer_timeout(): shoot();

### === Movement === ###

func _handle_direction(direction: Vector3): return direction + move(current_direction);

func _on_MovementChange_timeout():
	var rnd = rand_range(0, 10);
	
	if rnd > 0 and rnd < 2 or rnd < 4 and state == ALERT: current_direction = "forward";
	if rnd > 3 and rnd < 4: current_direction = "backward";
	if rnd > 5 and rnd < 6: current_direction = "left";
	if rnd > 7 and rnd < 8: current_direction = "right";
func _handle_just_jump(): if rand_range(0, 100) > 99: jumping = true;