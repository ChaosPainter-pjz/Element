using Base;
using Scene;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public class GameMode : SingletonMonoBase<GameMode>
    {
        public HeroesPrefab HeroesPrefab;
        [SerializeField] private BattleConfig m_battleConfig;
        public event UnityAction OnBattleStart;
        void Start()
        {
            for (var i = 0; i < m_battleConfig.BlueHeroes.Count; i++)
            {
                var hero = m_battleConfig.BlueHeroes[i];
                GenerateAHero(hero.Id, Camp.Blue, i);
            }

            for (var i = 0; i < m_battleConfig.RedHeroes.Count; i++)
            {
                var hero = m_battleConfig.RedHeroes[i];
                GenerateAHero(hero.Id, Camp.Red, i);
            }

            OnBattleStart?.Invoke();
        }
        /// <summary>
        /// 生成一个英雄单位
        /// </summary>
        /// <param name="key">Hero.Key</param>
        /// <param name="camp">阵营</param>
        /// <param name="index">出生点的序号</param>
        public void GenerateAHero(int key, Camp camp,int index)
        {

            var pair = HeroesPrefab.Heroes.Find(x => x.Id == key);
            var position = camp == Camp.Blue
                ? SceneManager.Instance.PointOfBirth.blue[index].position
                : SceneManager.Instance.PointOfBirth.red[index].position;
            var obj = Instantiate(pair.Value, position, Quaternion.identity);
            var hero = obj.GetComponent<Hero>();
            hero.Camp = camp;
            hero.Init();
            BattleManager.Instance.AddHero(hero);

        }
    }
}
