using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    [SerializeField] private AudioSource deathSound;

    private Animator _animator;
    private Rigidbody2D _rigidbody2D;

    private void Start() {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("Trap")) {
            Die();
        }
    }
    private void Die()
    {
        _rigidbody2D.bodyType = RigidbodyType2D.Static;
        _animator.SetTrigger("death");
        deathSound.Play();
    }

    private void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}