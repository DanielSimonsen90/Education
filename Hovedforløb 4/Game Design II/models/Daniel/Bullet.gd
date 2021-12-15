extends Area

var damage_given = 40;
var speed = 69;
var velocity = Vector3();

func start(xform):
	transform = xform;
	velocity = -transform.basis.z * speed;

func _process(delta): transform.origin += velocity * delta;

func _on_Timer_timeout(): queue_free(); # Remove from game

func _on_Bullet_body_entered(body):
	if body is StaticBody: 		queue_free();
	elif body.is_in_group("Player") or body.is_in_group("Enemy"):
		var base_player := body as BasePlayer;
		base_player.take_damage(damage_given);
		print(str("Gave ", body.name, " ", damage_given, " damage."))