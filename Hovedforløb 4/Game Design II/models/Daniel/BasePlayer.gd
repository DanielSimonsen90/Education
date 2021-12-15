extends KinematicBody
class_name BasePlayer

const initial_health = 100;
const base_speed = 4.0;
const jump_speed = 6;
const gravity_strength = 25;
const gravity = Vector3.DOWN * 15;

var Bullet = load("res://models/Daniel/Bullet.tscn");
var speed = base_speed;
var jumping = false;
var velocity = Vector3();
var health = initial_health;

#onready var Model = $MeshInstance;
#onready var Hitbox = $CollisionShape;
onready var BulletPos = $MeshInstance/Eye/Pivot/BulletPosition;

func take_damage(damage: int):
	health -= damage;
	
	if health > 0: return
	
	queue_free();
	print(str(name, " died"));

func shoot():
	var bullet = Bullet.instance();
	bullet.start(BulletPos.global_transform);
	get_parent().add_child(bullet);