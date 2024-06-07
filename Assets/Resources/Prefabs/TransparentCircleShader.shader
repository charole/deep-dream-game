Shader "Custom/TransparentCircleShader"
{
  Properties
  {
    _MainTex ("Texture", 2D) = "white" {}
    _CircleCenter ("Circle Center", Vector) = (0.5, 0.5, 0, 0)
    _CircleRadius ("Circle Radius", Float) = 0.2
    _CircleFeather ("Circle Feather", Float) = 0.05
  }
  SubShader
  {
    Tags { "RenderType"="Transparent" }
    LOD 100

    Pass
    {
      Blend SrcAlpha OneMinusSrcAlpha
      ZWrite Off
      CGPROGRAM
      #pragma vertex vert
      #pragma fragment frag
      #include "UnityCG.cginc"

      struct appdata
      {
        float4 vertex : POSITION;
        float2 uv : TEXCOORD0;
      };

      struct v2f
      {
        float2 uv : TEXCOORD0;
        float4 vertex : SV_POSITION;
      };

      sampler2D _MainTex;
      float4 _MainTex_ST;

      float4 _CircleCenter;
      float _CircleRadius;
      float _CircleFeather;

      v2f vert (appdata v)
      {
        v2f o;
        o.vertex = UnityObjectToClipPos(v.vertex);
        o.uv = TRANSFORM_TEX(v.uv, _MainTex);
        return o;
      }

      fixed4 frag (v2f i) : SV_Target
      {
        // Calculate distance from circle center
        float2 circleCenter = _CircleCenter.xy;
        float dist = distance(i.uv, circleCenter);

        // Calculate alpha based on distance and feather
        float alpha = smoothstep(_CircleRadius, _CircleRadius - _CircleFeather, dist);

        // Set color to black with varying alpha
        fixed4 col = fixed4(0, 0, 0, 1.0 - alpha);

        return col;
      }
      ENDCG
    }
  }
  FallBack "Diffuse"
}
