using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SpriteMaskController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private SpriteMask spriteMask;
    private Collider2D spriteMaskCollider;
    //List of objects that we are colliding with
    private List<SpriteRenderer> otherRendereres = new List<SpriteRenderer>();
    public bool checking = false;
    private void Awake()
    {
        spriteMaskCollider = GetComponent<Collider2D>(); 
        spriteMaskCollider.isTrigger = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (checking)
            {
            foreach (SpriteRenderer renderer in otherRendereres) 
                { 
                if (playerSpriteRenderer.sortingLayerName == renderer.sortingLayerName
                    && playerSpriteRenderer.sortingOrder <= renderer.sortingOrder
                    && playerSpriteRenderer.transform.position.y > renderer.transform.position.y) 
                        {
                    spriteMask.enabled = true;
                    playerSpriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                    return;
                }
                else
                {
                    spriteMask.enabled = false;
                    playerSpriteRenderer.maskInteraction = SpriteMaskInteraction.None;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger == false) 
            return; 
        SpriteRenderer spriteRenderer= collision.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            otherRendereres.Add(spriteRenderer);
            checking= true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger == false) 
           return;
        SpriteRenderer spriteRenderer= collision.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            otherRendereres.Remove(spriteRenderer);
            if (otherRendereres.Count <= 0)
            {
                checking= false;
                spriteMask.enabled = false;
                playerSpriteRenderer.maskInteraction = SpriteMaskInteraction.None;
            }
        }
    }
}
