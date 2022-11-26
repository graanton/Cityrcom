using System.Collections;
using UnityEngine;

namespace Tests
{
    public class RequestTester : MonoBehaviour, IRequester
    {
        [SerializeField] private InventoryGetter _lootGetter;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.5f);
            _lootGetter.RequestFromInventory<WeaponBase>(this);
        }

        public void OnRequestComplited(LootUIBox box)
        {
            print(box.loot.name);
        }
    }
}