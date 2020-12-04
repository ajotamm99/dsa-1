using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MovingObject {

	public int playerDamage;

	private Animator animator;
	private Transform target;
	private bool skipMove;
	public AudioClip enemyAttack1;
	public AudioClip enemyAttack2;
	private SpriteRenderer spriteRenderer;
	bool move = false;


	protected override void Start () {
		GameManager.instance.AddEnemyToList(this);
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		target = GameObject.FindGameObjectWithTag("Player").transform;
		base.Start();
	}

	protected override void AttemptMove<T>(int xDir, int yDir)
	{
		if (skipMove) {
			skipMove = false;
			return;
		}
		base.AttemptMove<T>(xDir, yDir);
		skipMove = true;
	}
	public void MoveEnemy() {
		int xDir = 0;
		int yDir = 0;
		bool horizontal = false;
		bool vertical = false;

		if (Mathf.Abs(target.position.x - transform.position.x) > float.Epsilon)
		{
			horizontal = true;
		}
		if (Mathf.Abs(target.position.y - transform.position.y) > float.Epsilon)
		{
			vertical = true;
		}

		if(vertical) {
			xDir = 0;
			yDir = target.position.y > transform.position.y ? 1 : -1;
			if(CanMove(xDir,yDir)) {
				AttemptMove<Player>(xDir, yDir);
				return;
			}
		}

		if (horizontal)
		{
			xDir = target.position.x > transform.position.x ? 1 : -1;
			yDir = 0;

			// Flips sprite following horizontal direction
			if(xDir < 0)
			{
				spriteRenderer.flipX = false;
			} else
			{
				spriteRenderer.flipX = true;
			}


			if (CanMove(xDir, yDir))
			{
				AttemptMove<Player>(xDir, yDir);
				return;
			}

		}

//		if (Mathf.Abs(target.position.x - transform.position.x) > float.Epsilon)
//		{
//			yDir = target.position.y > transform.position.y ? 1 : -1;
//			if (CanMove(xDir, yDir) == false)
//			{
//				yDir = 0;
//				xDir = target.position.x > transform.position.x ? 1 : -1;
//			}
//		}
//
//		else
//		{
//			xDir = target.position.x > transform.position.x ? 1 : -1;
//			if (CanMove(xDir, yDir) == false)
//			{
//				xDir = 0;
//				yDir = target.position.y > transform.position.y ? 1 : -1;
//			}
//		}
//
//		AttemptMove<Player>(xDir, yDir);

	}


	protected override void OnCantMove<T>(T component)
	{
		Player hitPlayer = component as Player;
		animator.SetTrigger("enemyAttack");
		hitPlayer.LoseFood(playerDamage);
		SoundManager.instance.RandomizeSfx(enemyAttack1, enemyAttack2);
	}
}