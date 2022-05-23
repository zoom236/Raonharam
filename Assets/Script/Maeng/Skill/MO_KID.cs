using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MO_KID : MonoBehaviour
{
    [Serializable]

    public class Dissolve
    {
        public enum MaterialPropertyType
        {
            Float
        }

        public string Name = "_DissolveValue";
        public MaterialPropertyType Type = MaterialPropertyType.Float;
        public AnimationCurve Curve = AnimationCurve.EaseInOut(0, 0, 1, 1);
        public float Duration = 0;
        [Space]
        public float FloatFrom = 0;
        public float FloatTo = 1;

        int propertyId;

        public void Init()
        {
            this.propertyId = Shader.PropertyToID(this.Name);
        }

        public void Update(Material material)
        {
            Duration += Time.deltaTime;

            float time = Curve.Evaluate(Duration);

            switch (Type)
            {
                case MaterialPropertyType.Float:
                    material.SetFloat(propertyId, Mathf.Lerp(FloatFrom, FloatTo, time));
                    break;
            }
        }
    }

    public Material material;
    public Dissolve[] animatedProperties;
    // ��ų ��Ÿ�� -> 10��
    // �ִϸ��̼� �ߵ�
    // ������ ��� �Ұ���
    // ��ų �ߵ��߿� �÷��̾ ���� �� ��ų ��������
    // �Ҹ� �ߵ� -> ����� �÷��̾ �鸲

    // Start is called before the first frame update
    void Awake()
    {
        if (animatedProperties != null)
        {
            foreach (var animatedProp in animatedProperties)
            {
                animatedProp.Init();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (animatedProperties != null)
        {
            foreach (var animatedProp in animatedProperties)
            {
                animatedProp.Update(material);
            }
        }
    }
}
