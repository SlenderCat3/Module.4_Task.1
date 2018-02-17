using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ImageProgressBar1 : MonoBehaviour
{
    public GameObject interactiveObject1;
	public UnityEvent onBarFilled1;

    [Header("Custom Settiings")]
	public bool alwaysFacePlayer = true;
    public bool disableOnFill1    = false;

	// Время в секундах необходимое для заполнения Progressbar'а
	public float timeToFill1 = 1.0f;

	// Переменная, куда будет сохранена ссылка на компонент Image
	// текущего объекта, который является ProgressBar'ом
	private Image progressBarImage1 = null;
	public Coroutine barFillCoroutine1 = null;

	void Start ()
	{
		// Получаем ссылку на компонент Image текущего объекта при
		// помощи метода GetComponent<>();
		progressBarImage1 = GetComponent<Image>();

		// Если у данного объекта нет компонента Image выводим ошибку
		// в консоль
		if(progressBarImage1 == null)
		{
			Debug.LogError("There is no referenced image on this component!");
		}

		// Создаём контроллер для события наведения указателя на объект
		EventTrigger eventTrigger = interactiveObject1.AddComponent<EventTrigger>();

		EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
		pointerEnter.eventID = EventTriggerType.PointerEnter;
		pointerEnter.callback.AddListener((eventData) => { StartFillingProgressBar1(); });
		eventTrigger.triggers.Add(pointerEnter);

		EventTrigger.Entry pointerExit = new EventTrigger.Entry();
		pointerExit.eventID = EventTriggerType.PointerExit;
		pointerExit.callback.AddListener((eventData) => { StopFillingProgressBar1(); });
		eventTrigger.triggers.Add(pointerExit);
	}

	void Update()
	{
		if(alwaysFacePlayer)
		transform.LookAt(TpPlayer.GetPosition());
	}

	void StartFillingProgressBar1()
	{
		barFillCoroutine1 = StartCoroutine("Fill");
	}

	void StopFillingProgressBar1()
	{
		StopCoroutine(barFillCoroutine1);
		progressBarImage1.fillAmount = 0.0f;
	}

	IEnumerator Fill()
	{
		float startTime = Time.time;
		float overTime = startTime + timeToFill1;

		while(Time.time < overTime)
		{
			progressBarImage1.fillAmount = Mathf.Lerp(0, 1, (Time.time - startTime) / timeToFill1);
			yield return null;
		}

		progressBarImage1.fillAmount = 0.0f;

		if(onBarFilled1 != null)
		{
			onBarFilled1.Invoke();
		}

        if(disableOnFill1)
        {
            transform.parent.gameObject.SetActive(false);
        }
	}
}