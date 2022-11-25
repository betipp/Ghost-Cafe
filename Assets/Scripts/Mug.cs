using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mug : MonoBehaviour
{

    public GameObject mLiquid;
    public GameObject mLiquidMesh;

    private int mSloshSpeed = 60;
    private int mRotateSpeed = 15;

    private int difference = 25;




    void Update()
    {
        //Motion
        Slosh();

        mLiquidMesh.transform.Rotate(Vector3.up * mRotateSpeed * Time.deltaTime, Space.Self);

    }

    private void Slosh()
    {
        // Inverse cup rotation
        Quaternion inverseRotation = Quaternion.Inverse(transform.localRotation);

        // Rotate to
        Vector3 finalRotation = Quaternion.RotateTowards(mLiquid.transform.localRotation, inverseRotation, mSloshSpeed * Time.deltaTime).eulerAngles;

        //Clamp the x and y axis
        finalRotation.x = ClampRotationValue(finalRotation.x, difference);
        finalRotation.z = ClampRotationValue(finalRotation.z, difference);

        //Set the tranformation
        mLiquid.transform.localEulerAngles = finalRotation;

    }


    private float ClampRotationValue(float value, float difference)
    {
        float returnValue = 0.0f;
        if (value > 180)
        {
            //Clamp
            returnValue = Mathf.Clamp(value, 360 - difference, 360);
        }
        else
        {
            //Clamp
            returnValue = Mathf.Clamp(value, 0, difference);
        }

        return returnValue;

    }




}
