
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace MFarm.Transition
{
    public class GameSceneManager : MonoSingleton<GameSceneManager>
    {
        public string startSceneName;
        public Vector3 startPos;
        private CanvasGroup canvasGroup;
        private Animator animator;
        protected override void Awake()
        {
            base.Awake();
            //加载UI场景
            SceneManager.LoadScene("UI", LoadSceneMode.Additive);
        }
        private void Start()
        {

        }

        private void OnTransitionEvent(string sceneName, Vector3 tarPos)
        {
            StartCoroutine(Transition(sceneName, tarPos));
        }

        //fuc1 切换场景
        private IEnumerator Transition(string sceneName, Vector3 tarPos)
        {
            // //1 场景切换前事件
            // EventHandler.CallBeforeSceneSwitch();
            //2 显示加载场景

            //3 异步卸载当前激活场景
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            //4 调用fuc2
            yield return LoadSceneSetActive(sceneName, tarPos);
            //5 退出加载场景



        }
        //fuc2 加载场景并设置激活
        private IEnumerator LoadSceneSetActive(string sceneName, Vector3 tarPos)
        {
            //1 异步附加场景
            yield return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            //2 获取当前附加的场景
            Scene newScene = SceneManager.GetSceneByName(sceneName);
            //3 设置当前场景为Active Scene
            SceneManager.SetActiveScene(newScene);

        }
        //func3 开始游戏调用的方法
        private void StartEndtEvent(bool start, bool newGame)
        {
            if (start)
            {
                StartCoroutine(GameStart(newGame));
            }
            else
            {
                GameEnd();
            }

        }
        //func4.1 开始游戏
        private IEnumerator GameStart(bool newGame)
        {
          
            
            //卸载之前的游戏场景
            if (SceneManager.GetActiveScene().name != "PersistentScene")
            {
                yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            }
           
            // 调用fuc2
            yield return LoadSceneSetActive(startSceneName, startPos);
            // 退出加载场景
        
         
        }
        //func4.2 返回主菜单
        private void GameEnd()
        {


        }


    }
}