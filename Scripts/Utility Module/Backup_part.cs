struct FCoordinate{
    float x,y,z,angle;
};

struct FCoordinate Position(float fx, float fy, float fz, float fangle){

    struct FCoordinate p;

    p.x = fx;
    p.y = fy;
    p.z = fz;
    p.angle = fangle;

    return p;
}

/*******************************************************************************
* Return a set of position for different companion.
*******************************************************************************/
struct FCoordinate GetFollowerPosition(string strTag){

    struct FCoordinate FollowerPosition = Position(0.0,0.0,0.0,0.0);

         if(strTag == GEN_FL_Ariane)    FollowerPosition = Position(1110.775, 800.5671, 12.52761,139.9);

    //Core Story
    else if(strTag == GEN_FL_Daveth)    FollowerPosition = Position(58.181 ,50.6084, 0.198706 ,45.0);
    else if(strTag == GEN_FL_Jory)      FollowerPosition = Position(58.2371,44.4582, 0.348582 ,139.9);
    else if(strTag == GEN_FL_Moira)     FollowerPosition = Position(55.7662,50.631 , 0.0960027,45.0);

    //Adopted Dalish
    else if(strTag == GEN_FL_Ilyana)    FollowerPosition = Position(50.4634,44.4572,0.0       ,139.9);
    else if(strTag == GEN_FL_Senros)    FollowerPosition = Position(50.562 ,50.6404,0.0       ,45.0);
    else if(strTag == GEN_FL_Dominique) FollowerPosition = Position(53.154 ,50.5959,0.0       ,45.0);
    else if(strTag == GEN_FL_Merrilyla) FollowerPosition = Position(53.2299,44.4601,0.0220574 ,139.9);
    else if(strTag == GEN_FL_Anaise)    FollowerPosition = Position(55.7778,44.4541,0.181982  ,139.9);



    return FollowerPosition;
}