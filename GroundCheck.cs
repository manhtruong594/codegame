 public bool GroundCheck()
    {
        float lenRay = 0.2f;

        RaycastHit2D[] rays =  Physics2D.BoxCastAll(colli.bounds.center, colli.bounds.size, 0f, Vector2.down, lenRay);
        Debug.DrawRay(colli.bounds.center + new Vector3(colli.bounds.extents.x, 0), Vector2.down * (colli.bounds.extents.y + lenRay), Color.red);
        Debug.DrawRay(colli.bounds.center - new Vector3(colli.bounds.extents.x, 0), Vector2.down * (colli.bounds.extents.y + lenRay), Color.red);
        Debug.DrawRay(colli.bounds.center - new Vector3(colli.bounds.extents.x, colli.bounds.extents.y+ lenRay), Vector2.right * (colli.bounds.extents.y + lenRay), Color.red);

        foreach (RaycastHit2D r in rays)
        {
            if (r.collider.CompareTag("Ground"))
            {
                return true;
            }
        }
        return false;
    }