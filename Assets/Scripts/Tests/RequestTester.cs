using System.Collections;
using UnityEngine;

namespace Tests
{
    public class RequestTester : MonoBehaviour
    {
        [SerializeField] private LootGetter _lootGetter;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(0.5f);
            _lootGetter.Request<WeaponBase>();
            _lootGetter.comliteEvent.AddListener(OnCompliteRequest);
        }

        private void OnCompliteRequest(LootBase loot)
        {
            print(loot.name);
        }
    }
}