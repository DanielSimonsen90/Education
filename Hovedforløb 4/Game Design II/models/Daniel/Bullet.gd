extends Area

var speed = 69;
var velocity = Vector3();

func start(xform):
	transform = xform;
	velocity = transform.basis.x * speed;

func _process(delta):
	transform.origin += velocity * delta;

func _on_Timer_timeout():
	queue_free(); # Remove from game


func _on_Bullet_body_entered(body):
	if body is StaticBody:
		queue_free();
