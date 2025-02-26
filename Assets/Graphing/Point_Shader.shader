Shader "Graph/Point_Shader"
{
    Properties
    {
        _Smoothness ("Smoothness", Range(0, 1)) = 0.5
    }
    SubShader
    {
        CGPROGRAM

        #pragma surface ConfigureSurface Standard fullforwardshadows
        #pragma target 3.0

        float _Smoothness;

        struct Input
        {
            float3 worldPos;
        };

        void ConfigureSurface(Input input, inout SurfaceOutputStandard surface)
        {
            surface.Albedo.rg = input.worldPos.xy * 0.5f + 0.5f;
            surface.Smoothness = _Smoothness;
        }

        ENDCG
    }

    Fallback "Diffuse"
}
