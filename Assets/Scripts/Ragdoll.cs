using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ragdoll : MonoBehaviour
{
    Animator anim;
    NavMeshAgent playerAgent;
    PathMover pathMover;

    public DOTweenUI DOTUI;
    public TimeCounter TC;

    private void Start()
    {
        anim = GetComponent<Animator>();
        playerAgent = GetComponent<NavMeshAgent>();
        pathMover = GetComponent<PathMover>();

        RGRigidbody(true);
        RDCollider(true);
    }

    private void Update()
    {
        if (playerAgent.velocity.magnitude <= 1f)
        {
            anim.SetBool("isRun", false);
        }
        else
        {
            anim.SetBool("isRun", true);
        }
        
    }

    void RGRigidbody(bool status)
    {
        Rigidbody[] rg = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rbChild in rg)
        {
            rbChild.isKinematic = status;
        }
    }

    void RDCollider(bool status)
    {
        Collider[] cl = GetComponentsInChildren<Collider>();
        foreach (Collider clChild in cl)
        {
            clChild.enabled = status;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        RagdollActive();
        DOTUI.restartGamePanel.SetActive(true);
        DOTUI.pathCreator.SetActive(false);
    }

    void RagdollActive()
    {
        anim.enabled = false;
        playerAgent.enabled = false;
        pathMover.enabled = false;
        RGRigidbody(false);
        RDCollider(true);
    }
    
    public void RagdollDeactive()
    {
        anim.enabled = true;
        playerAgent.enabled = true;
        pathMover.enabled = true;
        RGRigidbody(true);
        RDCollider(true);
    }
}
