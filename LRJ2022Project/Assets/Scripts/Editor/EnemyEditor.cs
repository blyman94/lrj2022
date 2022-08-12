using UnityEngine;
using UnityEditor;

//[CustomEditor(typeof(Enemy))]
[CanEditMultipleObjects]
public class EnemyEditor : Editor
{
    private SerializedProperty enemyDataProperty;
    private SerializedProperty onDamageEvent;
    private SerializedProperty onDeathEvent;

    private void OnEnable()
    {
        enemyDataProperty = serializedObject.FindProperty("EnemyData");
        onDamageEvent = serializedObject.FindProperty("EnemyDamagedEvent");

        onDeathEvent = serializedObject.FindProperty("EnemyDiedEvent");

    }

    public override void OnInspectorGUI()
    {
        var enemy = target as Enemy;

        // Draw the Unity-standard script field atop the inspector.
        using (new EditorGUI.DisabledScope(true))
            EditorGUILayout.ObjectField("Script",
            MonoScript.FromMonoBehaviour((MonoBehaviour)target),
            GetType(), false);

        EditorGUILayout.PropertyField(enemyDataProperty);
        
        EditorGUILayout.PropertyField(onDamageEvent);
        EditorGUILayout.PropertyField(onDeathEvent);



        if (GUILayout.Button("Take Damage"))
        {
            if (Application.isPlaying)
            {
                enemy.TakeDamage(1);
            }
        }
    }
}
