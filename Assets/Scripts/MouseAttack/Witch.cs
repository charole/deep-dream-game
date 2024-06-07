using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour
{
  public int damage = 3; // 플레이어에게 줄 데미지

  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.CompareTag("Player"))
    {
      PlayerHP playerHP = collision.GetComponent<PlayerHP>();
      if (playerHP != null)
      {
        playerHP.TakeDamage(damage);
      }
      Destroy(gameObject); // 충돌 후 Witch 파괴
    }
  }
}
