using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneReload : MonoBehaviour {

  public void Update() {
    if (!Input.GetKeyDown(KeyCode.Escape)){ return; }
    Scene scene = SceneManager.GetActiveScene();
    SceneManager.LoadScene(scene.name);
  }

}
