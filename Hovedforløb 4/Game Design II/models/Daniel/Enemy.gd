extends BasePlayer
class_name Enemy
#extends load("res://models/Daniel/BasePlayer.gd")

enum { IDLE, ALERT }

const turn_speed = 2;

var state = IDLE;
var target;

onready var Eyes = $Eyes;
onready var ShootTimer = $ShootTimer

func _process(delta):
	match state:
		IDLE: on_idle();
		ALERT: on_alert();

func on_idle(): pass;

func on_alert():
	Eyes.look_at(target.global_transform.origin, Vector3.UP);
	rotate_y(deg2rad(Eyes.rotation.y * turn_speed * 2))

func _on_SightRange_body_entered(body):
	if body.is_in_group("Player"):
		state = ALERT;
		target = body;
		ShootTimer.start();

func _on_SightRange_body_exited(body):
	state = IDLE;
	ShootTimer.stop();

func _on_ShootTimer_timeout(): pass;