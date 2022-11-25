using System.Collections;
using UnityEngine;

namespace Tests
{
    public class RequestTester : MonoBehaviour, IRequester
    {
        [SerializeField] private LootGetter _lootGetter;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.5f);
            _lootGetter.RequestFromInventory<WeaponBase>(this);
            _lootGetter.comliteEvent.AddListener(OnRequestComplited);
        }

        public void OnRequestComplited(LootUIBox box)
        {
            print(box.loot.name);
        }
    }
}