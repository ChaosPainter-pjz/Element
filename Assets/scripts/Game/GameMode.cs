using Base;
using Scene;
using UnityEngine;

namespace Game
{
    public class GameMode : SingletonMonoBase<GameMode>
    {
        public HeroesPrefab HeroesPrefab;

        protected override void Awake()
        {
            base.Awake();

        }

        void Start()
        {
            GenerateAHero(0, Camp.Blue, 0);
            GenerateAHero(2, Camp.Red, 0);
        }
        /// <summary>
        /// 生成一个英雄单位
        /// </summary>
        /// <param name="key">Hero.Key</param>
        /// <param name="camp">阵营</param>
        /// <param name="index">出生点的序号</param>
        public void GenerateAHero(int key, Camp camp,int index)
        {

            var pair = HeroesPrefab.Heroes.Find(x => x.Key == key);
            var position = camp == Camp.Blue
                ? SceneManager.Instance.PointOfBirth.blue[index].position
                : SceneManager.Instance.PointOfBirth.red[index].position;
            var obj = Instantiate(pair.Value, position, Quaternion.identity);
            var hero = obj.GetComponent<Hero>();
            hero.m_camp = camp;
            BattleManager.Instance.AddHero(hero);

        }
    }
}
