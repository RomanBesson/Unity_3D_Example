using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentManager : MonoBehaviour {

    private GameObject prefab_Student;
    private Teacher teacher;

	void Start () {
        prefab_Student = Resources.Load<GameObject>("Students/Student");
        teacher = GameObject.Find("Teacher").GetComponent<Teacher>();

        for (int i = 0; i < 5; i++)
        {
            Student student = GameObject.Instantiate<GameObject>(prefab_Student, new Vector3(0, i * 2, 0), Quaternion.identity).GetComponent<Student>();
            student.InitStudent("Student_" + i, teacher);

            teacher.Add(student);
        }
	}
	

}
