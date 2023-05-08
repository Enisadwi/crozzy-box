using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] Character selectedCharacter;
    [SerializeField] List<Character> characterList;
    [SerializeField] Transform Atkref;
    [SerializeField] UnityEvent onTakeDamage;
    [SerializeField] bool isBot;
  
    public Character SelectedCharacter { get => selectedCharacter; }
    public List<Character> CharacterList {get => characterList;}

    
    
    public void Prepare()
    {
        selectedCharacter = null;
    }

    public void SelectCharacter(Character character)
    {
        selectedCharacter = character;
    }

    public void SetPlay(bool value)
    {
        if(isBot)
        {
            int index = Random.Range(0,maxExclusive: characterList.Count);
            selectedCharacter = CharacterList[index];
        }
        else
        {
             
            foreach(var character in characterList)
        {
            character.Button.interactable = value ;
        }
        
        }
    
        }
        
    public void Attack()
    {
        selectedCharacter.transform.DOMove(endValue: Atkref.position, 0.5f);
    }
    public bool IsAttacking()
    {
         if (selectedCharacter == null)
        return false;

        return DOTween.IsTweening(targetOrId: selectedCharacter.transform);
    }
    public void TakeDamage(int damageValue)
    {
       selectedCharacter.ChangeHP(amount: -damageValue);
       var spriteRend = selectedCharacter.GetComponent<SpriteRenderer>();
       spriteRend.DOColor(endValue: Color.red,0.1f).SetLoops(6, loopType: LoopType.Yoyo);
       onTakeDamage.Invoke();
    }
    public bool IsDamaging()
    {
         if (selectedCharacter == null)
        return false;

        var spriteRend = selectedCharacter.GetComponent<SpriteRenderer>();
        return DOTween.IsTweening(targetOrId: spriteRend);
    }

    public void Remove(Character character)
    {
        if(characterList.Contains(item: character) == false)
        return;

        if(selectedCharacter == character)
        selectedCharacter = null;

        character.Button.interactable = false;
        character.gameObject.SetActive(false);
        characterList.Remove(item: character);
    }
    public void Return()
    {
        selectedCharacter.transform.DOMove(endValue: selectedCharacter.initialPosition, 0.5f);
    }
    public bool IsReturning()
    {
        if (selectedCharacter == null)
        return false;

        return DOTween.IsTweening(targetOrId: selectedCharacter.transform);
    }
}