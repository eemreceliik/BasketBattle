using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerManager : MonoBehaviour
{
    private Vector2
        _startedPos, // hareketin başladığı konum
        _delta; // hareketin devam ettiği konum

    private Vector2 _value; // hareket sonucunda yansıtılan değer


    public Vector2 GetValue() // Bu fonksiyonumuz karakter hareketini yazdığımız scriptten çağırılacak ve hareket koduna dahil edilecek.
    {
        return _value;
    }
    public float maxDistance = 100f; // kullanıcının hareketinin maksimum ne kadar olacağı
        
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            _startedPos = (Vector2) Input.mousePosition; // başlangıç konumunu alıyoruz
        if (Input.GetMouseButtonUp(0))
        { 
            // Değerleri sıfırlıyoruz hareket bittiği zaman
            _delta = Vector2.zero; 
            _startedPos = Vector2.zero;
            _value = Vector2.zero;
        }

        if (!Input.GetMouseButton(0)) return; // hareket ediyorsa hesaplamaları yapıyoruz
        _delta = (Vector2) Input.mousePosition - _startedPos;
        _delta.x = Mathf.Clamp(_delta.x, -maxDistance, maxDistance);
        _delta.y = Mathf.Clamp(_delta.y, -maxDistance, maxDistance);

        _value = _delta / maxDistance;
        _startedPos = (Vector2) Input.mousePosition;
    }
    
    
}
