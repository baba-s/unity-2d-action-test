using UnityEngine;

public class FragileBlock : MonoBehaviour
{
	public float m_timeDisableCollider;
	public float m_timeDestroy;

	private Animator m_animator;
	private bool m_isDestroyed;
	
	private void Awake()
	{
		var motor = GetComponent<MovingPlatformMotor2D>();
		motor.onPlatformerMotorContact += OnPlatformerMotorContact;

		m_animator = GetComponent<Animator>();
	}

	private void OnPlatformerMotorContact( PlatformerMotor2D player )
	{
		if ( m_isDestroyed ) return;
		m_isDestroyed = true;

		Invoke( "DisableCollider", m_timeDisableCollider );

		Destroy( gameObject, m_timeDestroy );
		m_animator.SetBool( "IsHit", true );
	}

	private void DisableCollider()
	{
		GetComponent<Collider2D>().enabled = false;
	}
}
