using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    [SerializeField] public Transform m_TargetRoot;
    [SerializeField] public Animator m_Animator;
    [SerializeField] public Transform m_Target;
    [SerializeField] public float m_MoveSpeed;
    private void Start()
    {
        m_Animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Vector3.Distance(m_Target.position, transform.position) > 0.15f)
            {
                transform.LookAt(m_Target);
                m_TargetRoot.position = transform.position;
                transform.Translate((Vector3.forward) * Time.deltaTime * (m_MoveSpeed));
                m_Animator.enabled = true;
            }
            else
            {
                m_Animator.enabled = false;
            }
        }
        else
        {
            m_Animator.enabled = false;
        }
    }
}

