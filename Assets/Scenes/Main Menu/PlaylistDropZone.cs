using UnityEngine;
using UnityEngine.EventSystems;

public class PlaylistDropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("DROP CALLED YAYYY");

        GameCardDrag drag = eventData.pointerDrag.GetComponent<GameCardDrag>();

        if (drag == null) return;

        RectTransform draggedRect = drag.GetComponent<RectTransform>();

        int newIndex = GetIndexFromPosition(draggedRect.position);

        drag.transform.SetParent(transform);
        drag.transform.SetSiblingIndex(newIndex);

        UpdatePlaylistOrder();
    }

    int GetIndexFromPosition(Vector2 dropPosition)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            RectTransform child =
                transform.GetChild(i).GetComponent<RectTransform>();

            if (dropPosition.y > child.position.y)
                return i;
        }

        return transform.childCount;
    }

    void UpdatePlaylistOrder()
    {
        Patient patient =
            DataManager.instance.CurrentPatient;

        if (patient == null) return;

        patient.GamePlaylist.Clear();

        foreach (Transform child in transform)
        {
            GameCard card = child.GetComponent<GameCard>();
            if (card != null)
                patient.GamePlaylist.Add(card.sessionData);
        }

        Debug.Log("Playlist order updated");
    }
}
